using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicCha.Repositories.Implementations
{
    public class ChallengeRepository : IChallengeRepository
    {
        private static Dictionary<int, ChallengeRM> _fakeChallenges = new Dictionary<int, ChallengeRM>()
        {
            { 1, new ChallengeRM(1, 1, "Геометрия", "Графически доказать теорему Пифагора", 999, 999) },
            { 2, new ChallengeRM(2, 1, "Алгебра", "Изобразить график функции (x - 1)^2 + (y + 1)^2 = 9", 1411, 2193) }
        };

        public async Task CreateChallenge(CreateChallangeRM model)
        {
            await new Task(() =>
                _fakeChallenges[_fakeChallenges.Last().Key] =
                    new ChallengeRM(_fakeChallenges.Last().Key, model.CreatorID, model.ChallengeName, model.ChallengeDescription, 0, 0));
        }

        public async Task<ChallengeRM> GetChallenge(int id)
        {
            return await new Task<ChallengeRM>(() => _fakeChallenges[id]);
        }

        public async Task<IEnumerable<ChallengeRM>> GetChallenges()
        {
            return await new Task<IEnumerable<ChallengeRM>>(() => _fakeChallenges.Values);
        }

        public async Task RemoveChallenge(int id)
        {
            await new Task(() => _fakeChallenges.Remove(id));
        }
    }
}
