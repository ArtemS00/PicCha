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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task CreateUser(CreateUserModelSM model)
        {
            var modelRM = _mapper.Map<CreateUserModelRM>(model);
            await _userRepository.CreateUser(modelRM);
        }

        public async Task<UserSM> GetUser(int id)
        {
            var userRM = await _userRepository.GetUser(id);
            return _mapper.Map<UserSM>(userRM);
        }

        public async Task<UserSM> GetUserByEmail(string email)
        {
            var userRM = await _userRepository.GetUserByEmail(email);
            return _mapper.Map<UserSM>(userRM);
        }

        public async Task<UserSM> GetUserByLogin(string login)
        {
            var userRM = await _userRepository.GetUserByLogin(login);
            return _mapper.Map<UserSM>(userRM);
        }
    }
}
