using PicCha.Services.Models.User;
using System.Threading.Tasks;

namespace PicCha.Services.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(CreateUserModelSM model);
        Task<UserSM> GetUser(int id);
        Task<UserSM> GetUserByEmail(string email);
        Task<UserSM> GetUserByLogin(string login);
        Task<UserInfoSM> GetUserInfo(UserSM userInfo, int userID);
    }
}
