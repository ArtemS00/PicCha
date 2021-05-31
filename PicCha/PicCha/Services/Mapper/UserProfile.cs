using AutoMapper;
using PicCha.Repositories.Models.User;
using PicCha.Services.Models.User;

namespace PicCha.Services.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRM, UserSM>();
            CreateMap<CreateUserModelSM, CreateUserModelRM>();
            CreateMap<UserInfoRM, UserInfoSM>();
        }
    }
}
