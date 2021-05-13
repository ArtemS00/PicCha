using AutoMapper;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System;
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

        public async Task CreateChallenge(UserSM userInfo, CreateChallengeSM model)
        {
            var modelRM = _mapper.Map<CreateChallengeSM, CreateChallangeRM>(model);
            modelRM.CreatorID = userInfo.UserID;
            await _challengeRepository.CreateChallenge(modelRM);
        }

        public async Task<ChallengeSM> GetChallenge(UserSM userInfo, int id)
        {
            var challengeRM = await _challengeRepository.GetChallenge(id);
            if (challengeRM == null)
                return null;
            var challengeSM = _mapper.Map<ChallengeSM>(challengeRM);
            var user = await _userRepository.GetUser(challengeSM.Creator.UserID);
            challengeSM.Creator = _mapper.Map<UserSM>(user);
            return challengeSM;
        }

        public async Task<IEnumerable<ChallengeSM>> GetChallenges(UserSM userInfo)
        {
            var challenges = await _challengeRepository.GetChallenges();
            var challengesSM = _mapper.Map<IEnumerable<ChallengeRM>, IEnumerable<ChallengeSM>>(challenges);

            // todo: set user
            return challengesSM;
        }

        public async Task RemoveChallenge(UserSM userInfo, int id)
        {
            var challenge = await _challengeRepository.GetChallenge(id);
            if (challenge == null)
                return;
            if (challenge.CreatorID != userInfo.UserID)
                throw new Exception("Доступ запрещен!");

            await _challengeRepository.RemoveChallenge(id);
        }
    }
}
