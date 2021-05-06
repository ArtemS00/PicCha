using Microsoft.AspNetCore.Mvc;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Auth;
using System;
using System.Threading.Tasks;

namespace PicCha.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid!");

            var token = await _authService.Login(loginModel);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid!");

            var token = await _authService.Register(registerModel);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
