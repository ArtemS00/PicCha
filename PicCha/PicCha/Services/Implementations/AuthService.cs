using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PicCha.Enums;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Auth;
using PicCha.Services.Models.User;
using PicCha.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PicCha.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private IOptions<AuthOptions> _authOptions;

        public AuthService(IUserService userService, IOptions<AuthOptions> authOptions)
        {
            _userService = userService;
            _authOptions = authOptions;
        }

        public async Task<string> Register(RegisterModel model)
        {
            if (model.Role != Role.User)
                throw new ArgumentException();
            if ((await _userService.GetUserByEmail(model.Email)) != null && (await _userService.GetUserByLogin(model.Login)) != null)
                throw new ArgumentException("Пользователь с таким логином или электронной почтой уже существует");

            await _userService.CreateUser(new CreateUserModelSM() { Email = model.Email, Login = model.Login, Password = model.Password });

            return GenerateJWT(await _userService.GetUserByEmail(model.Email));
        }

        public async Task<string> Login(LoginModel model)
        {
            var user = await _userService.GetUserByEmail(model.Email);
            if (user.Password != model.Password)
                throw new ArgumentException("Неправильный логин или пароль");

            return GenerateJWT(user);
        }

        private string GenerateJWT(UserSM user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim("userInfo", JsonConvert.SerializeObject(user))
            };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
