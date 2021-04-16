using PicCha.Repositories.Models.Challenge;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Repositories.Interfaces
{
    public interface IChallengeRepository
    {
        Task<IEnumerable<ChallengeRM>> GetChallenges();
        Task<ChallengeRM> GetChallenge(int id);
        Task CreateChallenge(CreateChallangeRM model);
        Task RemoveChallenge(int id);
    }
}
