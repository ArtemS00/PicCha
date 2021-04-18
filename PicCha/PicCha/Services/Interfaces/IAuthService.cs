using PicCha.Services.Models.Auth;
using System.Threading.Tasks;

namespace PicCha.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel model);
        Task<string> Register(RegisterModel model);
    }
}
