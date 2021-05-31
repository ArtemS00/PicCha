using System;

namespace PicCha.Services.Models.User
{
    public class UserInfoSM
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public byte[] Image { get; set; }
        public int ChallengesCount { get; set; }
        public int WorksCount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
