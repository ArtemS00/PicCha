using Autofac;
using AutoMapper;
using PicCha.Repositories.Implementations;
using PicCha.Repositories.Interfaces;
using PicCha.Services.Implementations;
using PicCha.Services.Interfaces;
using PicCha.Services.Mapper;

namespace PicCha
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterMapperProfiles(builder);
            RegisterTypes(builder);
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<ChallengeService>().As<IChallengeService>();
            builder.RegisterType<ChallengeRepository>().As<IChallengeRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }

        private static void RegisterMapperProfiles(ContainerBuilder builder)
        {
            builder.Register(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ChallengeProfile());
            }).CreateMapper());
        }
}
}
