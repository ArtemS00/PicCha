using PicCha.Repositories.Models.User;
using PicCha.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PicCha.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRM> GetUser(int id);
        Task<UserRM> GetUserByEmail(string email);
        Task<UserRM> GetUserByLogin(string login);
        Task CreateUser(CreateUserModelRM model);
        Task<IEnumerable<UserRM>> GetUsers(IEnumerable<int> userIDs);
    }
}
