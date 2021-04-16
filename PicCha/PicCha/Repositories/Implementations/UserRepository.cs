using PicCha.Repositories.Interfaces;
using PicCha.Repositories.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicCha.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly Dictionary<int, UserRM> _fakeUsers = new Dictionary<int, UserRM>()
        {
            { 1, new UserRM(1, "mango_tasty1", null) }
        };

        public async Task<UserRM> GetUser(int id)
        {
            return await new Task<UserRM>(() => _fakeUsers[id]);
        }
    }
}
