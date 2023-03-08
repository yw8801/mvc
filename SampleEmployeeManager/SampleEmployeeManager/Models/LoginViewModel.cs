using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class LoginViewModel
    {
        [Display(Name = "ユーザー名：")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "パスワード：")]
        public string Password { get; set; }
    }
}