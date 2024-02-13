using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Watch_Store_Management_Web_API.BusinessLogicLayer.DataTransferObjects.Login;
using Watch_Store_Management_Web_API.BusinessLogicLayer.Services;
using Watch_Store_Management_Web_API.Infrastructure;

namespace Watch_Store_Management_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IConfiguration configuration;
        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            this.authService = authService;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            var result = await authService.IsValidUser(loginRequestDTO);
            if (result is not null)
            {
                return Ok(result);
            }
            return Unauthorized(new { message = "Invalid Login!" });
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var roleName = User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault();
        //    return Ok($"You are having {roleName.Value} Role");
        //}

        //[HttpGet("admin")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> GetForAdmin()
        //{
        //    return Ok("You are an ADMIN!");
        //}
    }
}
