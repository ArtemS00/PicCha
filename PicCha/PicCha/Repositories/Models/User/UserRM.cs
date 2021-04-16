namespace PicCha.Repositories.Models.User
{
    public class UserRM
    {
        public UserRM() { }
        public UserRM(int iD, string login, byte[] image)
        {
            ID = iD;
            Login = login;
            Image = image;
        }

        public int ID { get; set; }
        public string Login { get; set; }
        public byte[] Image { get; set; }
    }
}
