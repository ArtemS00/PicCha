using PicCha.Enums;
using System.ComponentModel.DataAnnotations;

namespace PicCha.Services.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [MinLength(5)]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Login { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(128)]
        public string Password { get; set; }

        public Role Role { get; set; } = Role.User;
    }
}
