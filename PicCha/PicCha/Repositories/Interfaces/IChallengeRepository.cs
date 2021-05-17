using PicCha.Repositories.Models.Challenge;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Repositories.Interfaces
{
    public interface IChallengeRepository
    {
        Task<IEnumerable<ChallengeRM>> GetChallenges(int userID = 0);
        Task<ChallengeRM> GetChallenge(int userID, int challengeID);
        Task CreateChallenge(CreateChallangeRM model);
        Task RemoveChallenge(int id);
        Task LikeChallenge(int challengeID, int userID);
        Task UnlikeChallenge(int challengeID, int userID);
        Task CreateChallengeWork(int challengeID, int authorID, byte[] work, string comment);
        Task LikeChallengeWork(int challengeWorkID, int userID);
        Task UnlikeChallengeWork(int challengeWorkID, int userID);
    }
}
