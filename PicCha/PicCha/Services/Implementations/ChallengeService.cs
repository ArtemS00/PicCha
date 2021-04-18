using AutoMapper;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Services.Implementations
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository _challengeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChallengeService(IChallengeRepository challengeRepository, IUserRepository userRepository, IMapper mapper)
        {
            _challengeRepository = challengeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateChallenge(CreateChallengeSM model)
        {
            var modelRM = _mapper.Map<CreateChallengeSM, CreateChallangeRM>(model);
            await _challengeRepository.CreateChallenge(modelRM);
        }

        public async Task<ChallengeSM> GetChallenge(int id)
        {
            var challengeRM = await _challengeRepository.GetChallenge(id);
            var challengeSM = _mapper.Map<ChallengeSM>(challengeRM);
            var user = await _userRepository.GetUser(challengeSM.Creator.UserID);
            challengeSM.Creator = _mapper.Map<UserSM>(user);
            return challengeSM;
        }

        public async Task<IEnumerable<ChallengeSM>> GetChallenges()
        {
            var challenges = await _challengeRepository.GetChallenges();
            var challengesSM = _mapper.Map<IEnumerable<ChallengeRM>, IEnumerable<ChallengeSM>>(challenges);

            // todo: set user
            return challengesSM;
        }

        public async Task RemoveChallenge(int id)
        {
            await _challengeRepository.RemoveChallenge(id);
        }
    }
}
