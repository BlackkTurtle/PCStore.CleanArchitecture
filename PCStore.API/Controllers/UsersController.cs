using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCStore.API.Models;
using PCStore.Application.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUserService usersservice;
        private IConfiguration _config;
        private PcstoreContext context;
        public UsersController(ILogger<UsersController> logger,
            IUserService ado_unitofwork,
            IConfiguration config,PcstoreContext context)
        {
            _logger = logger;
            usersservice = ado_unitofwork;
            _config = config;
            this.context = context;
        }
        [AllowAnonymous]
        [HttpPost("/GetToken")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(await user.ConfigureAwait(false));
                return Ok(token);
            }
            return NotFound("User not found!");
        }

        private string Generate(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9"));
            var credentials=new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Surname,user.LastName),
                new Claim(ClaimTypes.GivenName,user.FirstName),
                new Claim(ClaimTypes.OtherPhone,user.Phone),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],claims,expires:DateTime.Now.AddHours(1),signingCredentials:credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<User?> Authenticate(UserLogin userLogin)
        {
            if (userLogin.UserName==null || userLogin.Password == null)
            {
                return null;
            }
            var currentUser = usersservice.GetByUserNameAndPassword(userLogin.UserName,userLogin.Password);
            if (currentUser != null)
            {
                return await currentUser;
            }
            return null;
        }

        [AllowAnonymous]
        [HttpGet("Phone/{Phone}")]
        public async Task<ActionResult<User>> GetUserByPhoneAsync(string Phone)
        {
            try
            {
                var results = await usersservice.GetByPhone(Phone);
                _logger.LogInformation($"Отримали всі User з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetUserByPhoneAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [AllowAnonymous]
        [HttpGet("Email/{Email}")]
        public async Task<ActionResult<User>> GetUserByEmailAsync(string Email)
        {
            try
            {
                var results = await usersservice.GetByEmail(Email);
                _logger.LogInformation($"Отримали всі User з бази даних!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetUserByEmailAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
        [AllowAnonymous]
        [HttpGet("id/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(string id)
        {
            try
            {
                var result = await usersservice.GetById(id);
                if (result == null)
                {
                    _logger.LogInformation($"User із Id: {id}, не був знайдейний у базі даних");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Отримали User з бази даних!");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі GetUserByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }


        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(string id, [FromBody] User updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    _logger.LogInformation($"Empty JSON received from the client");
                    return BadRequest("User object is null");
                }

                await usersservice.Update(id,updatedUser);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction failed! Something went wrong in UpdateUserAsync() method - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error occurred.");
            }
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserByIdAsync(string id)
        {
            try
            {
                await usersservice.Remove(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі DeleteUserByIdAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }
    }
}
