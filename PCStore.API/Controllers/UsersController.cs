using System.CodeDom.Compiler;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCStore.API.Models;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Infrastructure.PCStoreDataBaseContext;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private IUsersService usersservice;
        private IConfiguration _config;
        private PcstoreContext context;
        public UsersController(ILogger<UsersController> logger,
            IUsersService ado_unitofwork,
            IConfiguration config,PcstoreContext context)
        {
            _logger = logger;
            usersservice = ado_unitofwork;
            _config = config;
            this.context = context;
        }
        [AllowAnonymous]
        [HttpPost("/GetToken")]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
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
        private User Authenticate(UserLogin userLogin)
        {
            var currentUser = context.Users.FirstOrDefault(u => u.UserName == userLogin.UserName&&u.Password==userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }

        [AllowAnonymous]
        [HttpGet("Phone/{Phone}")]
        public async Task<ActionResult<User>> GetUserByPhoneAsync(string Phone)
        {
            try
            {
                var results = await usersservice.GetUserByPhoneAsync(Phone);
                _logger.LogInformation($"Отримали всі User з бази даних!");
                await usersservice.SaveChangesAsync();
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
                var results = await usersservice.GetUserByEmailAsync(Email);
                _logger.LogInformation($"Отримали всі User з бази даних!");
                await usersservice.SaveChangesAsync();
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
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await usersservice.GetByIdAsync(id);
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

        /*[AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> PostUserAsync([FromBody] User fulluser)
        {
            try
            {
                if (fulluser == null)
                {
                    _logger.LogInformation($"Ми отримали пустий json зі сторони клієнта");
                    return BadRequest("Обєкт User є null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"Ми отримали некоректний json зі сторони клієнта");
                    return BadRequest("Обєкт User є некоректним");
                }
                var user = new User()
                {
                    UserName=fulluser.UserName,
                    Password = fulluser.Password,
                    Email = fulluser.Email,
                    FirstName = fulluser.FirstName,
                    LastName=fulluser.LastName,
                    Father = fulluser.Father,
                    Phone = fulluser.Phone,
                    Role=fulluser.Role
                };
                await usersservice.AddAsync(user);
                await usersservice.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Транзакція сфейлилась! Щось пішло не так у методі PostUserAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "вот так вот!");
            }
        }*/

        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(int id, [FromBody] User updatedUser)
        {
            try
            {
                if (updatedUser == null)
                {
                    _logger.LogInformation($"Empty JSON received from the client");
                    return BadRequest("User object is null");
                }

                var UserEntity = await usersservice.GetByIdAsync(id);
                if (UserEntity == null)
                {
                    _logger.LogInformation($"User with ID: {id} was not found in the database");
                    return NotFound();
                }
                UserEntity.Password = updatedUser.Password;
                UserEntity.FirstName = updatedUser.FirstName;
                UserEntity.LastName = updatedUser.LastName;
                UserEntity.Father = updatedUser.Father;
                UserEntity.Phone = updatedUser.Phone;
                UserEntity.Email = updatedUser.Email;
                UserEntity.Role= updatedUser.Role;

                await usersservice.SaveChangesAsync();
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
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            try
            {
                await usersservice.DeleteByIdAsync(id);
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
