namespace PicCha.Repositories.Models.User
{
    public class UserRM
    {
        public UserRM() { }
        public UserRM(int id, string login, byte[] image)
        {
            UserID = id;
            Login = login;
            Image = image;
        }

        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public int Role { get; set; }
    }
}
