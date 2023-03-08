using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class UserModel
    {
        [Key]
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
    }
}