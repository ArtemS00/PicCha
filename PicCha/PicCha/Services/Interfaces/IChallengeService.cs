using PicCha.Services.Models.Challenge;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Services.Interfaces
{
    public interface IChallengeService
    {
        Task<IEnumerable<ChallengeSM>> GetChallenges();
        Task<ChallengeSM> GetChallenge(int id);
        Task CreateChallenge(CreateChallengeSM model);
        Task RemoveChallenge(int id);
    }
}
