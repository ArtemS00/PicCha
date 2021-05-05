using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Services.Interfaces
{
    public interface IChallengeService
    {
        Task<IEnumerable<ChallengeSM>> GetChallenges(UserSM userInfo);
        Task<ChallengeSM> GetChallenge(UserSM userInfo, int id);
        Task CreateChallenge(UserSM userInfo, CreateChallengeSM model);
        Task RemoveChallenge(UserSM userInfo, int id);
    }
}
