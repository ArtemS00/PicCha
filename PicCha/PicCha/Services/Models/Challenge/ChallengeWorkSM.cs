using System;

namespace PicCha.Services.Models.Challenge
{
    public class ChallengeWorkSM
    {
        public int ChallengeID { get; set; }
        public int ChallengeWorkID { get; set; }
        public string Comment { get; set; }
        public byte[] Work { get; set; }
        public bool Liked { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LikesCount { get; set; }

        public int AuthorID { get; set; }
        public string AuthorLogin { get; set; }
        public byte[] AuthorImage { get; set; }
    }
}
