namespace PicCha.Repositories.Models.Challenge
{
    public class ChallengeRM
    {
        public ChallengeRM() { }

        public ChallengeRM(int challangeID, int creatorID, string challengeName, string challengeDescription, int likesCount, int participationsCount)
        {
            ChallangeID = challangeID;
            CreatorID = creatorID;
            ChallengeName = challengeName;
            ChallengeDescription = challengeDescription;
            LikesCount = likesCount;
            ParticipationsCount = participationsCount;
        }

        public int ChallangeID { get; set; }
        public int CreatorID { get; set; }
        public string ChallengeName { get; set; }
        public string ChallengeDescription { get; set; }
        public int LikesCount { get; set; }
        public int ParticipationsCount { get; set; }
    }
}
