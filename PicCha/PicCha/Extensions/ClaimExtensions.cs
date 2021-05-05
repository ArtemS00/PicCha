using Newtonsoft.Json;
using PicCha.Services.Models.User;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace PicCha.Extensions
{
    public static class ClaimsExtensions
    {
        public static UserSM GetUserInfo(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("userInfo");
            if (claim == null)
            {
                throw new Exception("Ошибка при инициализации User");
            }

            try
            {
                return JsonConvert.DeserializeObject<UserSM>(claim.Value);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при инициализации User", ex);
            }
        }
    }
}
