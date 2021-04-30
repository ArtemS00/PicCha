using Autofac;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PicCha.Repositories.Implementations;
using PicCha.Repositories.Interfaces;
using PicCha.Services.Implementations;
using PicCha.Services.Interfaces;
using PicCha.Services.Mapper;
using PicCha.Settings;

namespace PicCha
{
    public class WebModule : Module
    {
        private readonly IConfigurationRoot _configuration;

        public WebModule(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => GetConnectionStrings()).SingleInstance();
            RegisterMapperProfiles(builder);
            RegisterTypes(builder);
        }

        private ConnectionStringsConfig GetConnectionStrings()
        {
            var result = new ConnectionStringsConfig
            {
                Default = _configuration.GetConnectionString("Default")
            };
            return result;
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<ChallengeService>().As<IChallengeService>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<ChallengeRepository>().As<IChallengeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }

        private static void RegisterMapperProfiles(ContainerBuilder builder)
        {
            builder.Register(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ChallengeProfile());
                cfg.AddProfile(new UserProfile());
            }).CreateMapper());
        }
}
}
