using AutoMapper;
using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.Challenge;
using PicCha.Repositories.Models.User;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var challengeRM = await _challengeRepository.GetChallenge(userInfo.UserID, id);
            if (challengeRM == null)
                return null;
            var challengeSM = _mapper.Map<ChallengeSM>(challengeRM);
            var user = await _userRepository.GetUser(challengeSM.Creator.UserID);
            challengeSM.Creator = _mapper.Map<UserSM>(user);
            return challengeSM;
        }

        public async Task<IEnumerable<ChallengeSM>> GetChallenges(UserSM userInfo)
        {
            var challenges = await _challengeRepository.GetChallenges(userInfo.UserID);
            var challengesSM = _mapper.Map<IEnumerable<ChallengeRM>, IEnumerable<ChallengeSM>>(challenges).ToList();

            var ids = challengesSM.Select(c => c.Creator.UserID).ToList();
            var users = await _userRepository.GetUsers(ids);
            var usersSM = _mapper.Map<IEnumerable<UserSM>>(users).ToList();
            for (int i = 0; i < challengesSM.Count; i++)
                challengesSM[i].Creator = usersSM[i];
            return challengesSM;
        }

        public async Task<IEnumerable<ChallengeSM>> GetChallenges()
        {
            var challenges = await _challengeRepository.GetChallenges();
            var challengesSM = _mapper.Map<IEnumerable<ChallengeRM>, IEnumerable<ChallengeSM>>(challenges).ToList();

            var ids = challengesSM.Select(c => c.Creator.UserID).ToList();
            var users = await _userRepository.GetUsers(ids);
            var usersSM = _mapper.Map<IEnumerable<UserSM>>(users).ToList();
            for (int i = 0; i < challengesSM.Count; i++)
                challengesSM[i].Creator = usersSM[i];
            return challengesSM;
        }

        public async Task RemoveChallenge(UserSM userInfo, int id)
        {
            var challenge = await _challengeRepository.GetChallenge(userInfo.UserID, id);
            if (challenge == null)
                return;
            if (challenge.CreatorID != userInfo.UserID && userInfo.Role != 2)
                throw new Exception("Доступ запрещен!");

            await _challengeRepository.RemoveChallenge(id);
        }

        public async Task LikeChallenge(UserSM userInfo, int challengeID)
        {
            await _challengeRepository.LikeChallenge(challengeID, userInfo.UserID);
        }

        public async Task UnlikeChallenge(UserSM userInfo, int challengeID)
        {
            await _challengeRepository.UnlikeChallenge(challengeID, userInfo.UserID);
        }

        public async Task LikeChallengeWork(UserSM userInfo, int challengeWorkID)
        {
            await _challengeRepository.LikeChallengeWork(challengeWorkID, userInfo.UserID);
        }

        public async Task UnlikeChallengeWork(UserSM userInfo, int challengeWorkID)
        {
            await _challengeRepository.UnlikeChallengeWork(challengeWorkID, userInfo.UserID);
        }

        public async Task CreateChallengeWork(UserSM userInfo, int challengeID, string comment, byte[] work)
        {
            await _challengeRepository.CreateChallengeWork(challengeID, userInfo.UserID, work, comment);
        }

        public async Task<IEnumerable<ChallengeWorkSM>> GetChallengeWorks(UserSM userInfo, int challengeID)
        {
            var works = await _challengeRepository.GetChallengeWorks(userInfo.UserID, challengeID);
            return _mapper.Map<IEnumerable<ChallengeWorkSM>>(works).ToList();
        }

        public async Task<IEnumerable<ChallengeSM>> GetUserChallenges(UserSM userInfo, int userID)
        {
            var challengeIDs = (await _challengeRepository.GetUserChallenges(userID)).ToList();
            if (challengeIDs.Count == 0)
                return new List<ChallengeSM>();
            var challenges = await _challengeRepository.GetChallenges(userInfo.UserID, challengeIDs);
            var challengesSM = _mapper.Map<IEnumerable<ChallengeSM>>(challenges).ToList();
            var ids = challengesSM.Select(c => c.Creator.UserID).ToList();
            var users = await _userRepository.GetUsers(ids);
            var usersSM = _mapper.Map<IEnumerable<UserSM>>(users).ToList();
            for (int i = 0; i < challengesSM.Count; i++)
                challengesSM[i].Creator = usersSM[i];
            return challengesSM;
        }
    }
}
