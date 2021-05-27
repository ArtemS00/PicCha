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

        [HttpGet("getChallengesForGuest")]
        public async Task<IActionResult> GetForGuest()
        {
            return Ok(await _challengeService.GetChallenges());
        }

        [HttpGet("getChallenges")]
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

        [HttpPost("likeChallenge")]
        [Authorize]
        public async Task<IActionResult> LikeChallenge(int challengeID)
        {
            await _challengeService.LikeChallenge(User.Identity.GetUserInfo(), challengeID);
            return Ok();
        }

        [HttpPost("unlikeChallenge")]
        [Authorize]
        public async Task<IActionResult> UnlikeChallenge(int challengeID)
        {
            await _challengeService.UnlikeChallenge(User.Identity.GetUserInfo(), challengeID);
            return Ok();
        }

        [HttpPost("likeChallengeWork")]
        [Authorize]
        public async Task<IActionResult> LikeChallengeWork(int challengeWorkID)
        {
            await _challengeService.LikeChallengeWork(User.Identity.GetUserInfo(), challengeWorkID);
            return Ok();
        }

        [HttpPost("unlikeChallengeWork")]
        [Authorize]
        public async Task<IActionResult> UnlikeChallengeWork(int challengeWorkID)
        {
            await _challengeService.UnlikeChallengeWork(User.Identity.GetUserInfo(), challengeWorkID);
            return Ok();
        }

        [HttpPost("createChallengeWork")]
        [Authorize]
        public async Task<IActionResult> CreateChallengeWork(int challengeID, string comment, byte[] work)
        {
            await _challengeService.CreateChallengeWork(User.Identity.GetUserInfo(), challengeID, comment, work);
            return Ok();
        }

        [HttpGet("getChallengeWorks")]
        [Authorize]
        public async Task<IActionResult> GetChallengeWorks(int challengeID)
        {
            var result = await _challengeService.GetChallengeWorks(User.Identity.GetUserInfo(), challengeID);
            return Ok(result);
        }
    }
}
