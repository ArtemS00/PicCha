using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicCha.Services;
using PicCha.Services.Models.Challenge;

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
        public async Task<IActionResult> Get()
        {
            return Ok(await _challengeService.GetChallenges());
        }

        [HttpGet("getChallenge")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _challengeService.GetChallenge(id));
        }

        [HttpPost("createChallenge")]
        public async Task<IActionResult> Post([FromBody]CreateChallengeSM value)
        {
            await _challengeService.CreateChallenge(value);
            return Ok();
        }

        [HttpDelete("deleteChallenge")]
        public async Task<IActionResult> Delete(int id)
        {
            await _challengeService.RemoveChallenge(id);
            return Ok();
        }
    }
}
