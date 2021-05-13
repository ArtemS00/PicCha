using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PicCha.Extensions;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Challenge;
using System.Threading.Tasks;

namespace PicCha.Controllers
{
    [Route("api/[controller]")]
    public class ChallengeController : Controller
    {
        private readonly IChallengeService _challengeService;
        public ChallengeController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet("getChallenges")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _challengeService.GetChallenges(User.Identity.GetUserInfo()));
        }

        [HttpGet("getChallenge")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _challengeService.GetChallenge(User.Identity.GetUserInfo(), id));
        }

        [HttpPost("createChallenge")]
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CreateChallengeSM value)
        {
            await _challengeService.CreateChallenge(User.Identity.GetUserInfo(), value);
            return Ok();
        }

        [HttpDelete("deleteChallenge")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _challengeService.RemoveChallenge(User.Identity.GetUserInfo(), id);
            return Ok();
        }
    }
}
