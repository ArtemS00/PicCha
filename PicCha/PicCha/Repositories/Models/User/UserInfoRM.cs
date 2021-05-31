using System;

namespace PicCha.Repositories.Models.User
{
    public class UserInfoRM
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public byte[] Image { get; set; }
        public int ChallengesCount { get; set; }
        public int WorksCount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
