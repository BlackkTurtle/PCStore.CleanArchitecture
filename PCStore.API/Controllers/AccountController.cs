using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PCStore.API.Models;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;
using PCStore.Infrastructure.Identity;

namespace PCStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        /*
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _identityService.CreateUserAsync(request.UserName, request.Email, request.Password);

            if (result.Succeeded)
            {
                var user = await _identityService.GetUserAsync(request.UserName);
                return Ok(new RegisterResponse { UserId = user.Id });
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _identityService.SignInAsync(request.UserName, request.Password, false);

            if (result.Succeeded)
            {
                var user = await _identityService.GetUserAsync(request.UserName);
                var roles = await _identityService.GetUserRolesAsync(user);

                return Ok(new LoginResponse { UserId = user.Id, Roles = roles });
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var userName = User.Identity.Name;

            if (userName != null)
            {
                var user = await _identityService.GetUserAsync(userName);
                var roles = await _identityService.GetUserRolesAsync(user);

                return Ok(new LoginResponse { UserId = user.Id, Roles = roles });
            }

            return BadRequest();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _identityService.SignOutAsync();
            return Ok();
        }*/
    }
}
