﻿namespace PicCha.Services.Models.User
{
    public class UserSM
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public int Role { get; set; }
    }
}
