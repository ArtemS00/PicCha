using PicCha.Services.Models.User;

namespace PicCha.Services.Models.Challenge
{
    public class ChallengeSM
    {
        public int ChallengeID { get; set; }
        public string ChallengeName { get; set; }
        public string ChallengeDescription { get; set; }
        public int LikesCount { get; set; }
        public int ParticipationsCount { get; set; }

        public UserSM Creator { get; set; }
        public bool Liked { get; set; }
        public bool Participated { get; set; }
    }
}
