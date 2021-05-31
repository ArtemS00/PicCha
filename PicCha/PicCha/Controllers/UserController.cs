using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicCha.Extensions;
using PicCha.Services.Interfaces;
using System.Threading.Tasks;

namespace PicCha.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getUserInfo")]
        [Authorize]
        public async Task<IActionResult> GetUserInfo(int userID)
        {
            var result = await _userService.GetUserInfo(User.Identity.GetUserInfo(), userID);
            return Ok(result);
        }
    }
}
