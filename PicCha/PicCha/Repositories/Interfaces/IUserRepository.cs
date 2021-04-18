using PicCha.Repositories.Models.User;
using PicCha.Services.Models.User;
using System.Threading.Tasks;

namespace PicCha.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRM> GetUser(int id);
        Task<UserRM> GetUserByEmail(string email);
        Task<UserRM> GetUserByLogin(string login);
        Task CreateUser(CreateUserModelRM model);
    }
}
