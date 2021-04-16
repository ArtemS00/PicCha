using AutoMapper;
using PicCha.Repositories.Models.Challenge;
using PicCha.Services.Models.Challenge;
using PicCha.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PicCha.Services.Mapper
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<CreateChallengeSM, CreateChallangeRM>();
            CreateMap<ChallengeRM, ChallengeSM>()
                .ForMember(c => c.Creator, c => c.MapFrom(src => new UserSM() { ID = src.CreatorID }));
        }
    }
}
