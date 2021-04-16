using PicCha.Repositories.Models.User;
using System.Threading.Tasks;

namespace PicCha.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserRM> GetUser(int id);
    }
}
