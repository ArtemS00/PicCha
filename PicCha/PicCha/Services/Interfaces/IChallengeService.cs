using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Services.Interfaces
{
    public interface IChallengeService
    {
        Task<IEnumerable<ChallengeSM>> GetChallenges();
        Task<IEnumerable<ChallengeSM>> GetChallenges(UserSM userInfo);
        Task<ChallengeSM> GetChallenge(UserSM userInfo, int id);
        Task CreateChallenge(UserSM userInfo, CreateChallengeSM model);
        Task RemoveChallenge(UserSM userInfo, int id);
        Task LikeChallenge(UserSM userInfo, int challengeID);
        Task UnlikeChallenge(UserSM userInfo, int challengeID);
        Task LikeChallengeWork(UserSM userInfo, int challengeWorkID);
        Task UnlikeChallengeWork(UserSM userInfo, int challengeWorkID);
        Task CreateChallengeWork(UserSM userInfo, int challengeID, string comment, byte[] work);
        Task<IEnumerable<ChallengeWorkSM>> GetChallengeWorks(UserSM userInfo, int challengeID);
        Task<IEnumerable<ChallengeSM>> GetUserChallenges(UserSM userInfo, int userID);
    }
}
