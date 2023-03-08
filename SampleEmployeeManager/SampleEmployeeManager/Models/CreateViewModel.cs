using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class CreateViewModel
    {
        [Display(Name = "社員ID：")]
        [Required]
        public string Id { get; set; }

        [Display(Name = "名前：")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "職位：")]
        public string Position { get; set; }

        [Display(Name = "入社時間：")]
        public string StartDate { get; set; }
    }
}