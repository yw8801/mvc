using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class UpdateViewModel : CreateViewModel
    {
        [Display(Name = "新しい名前：")]
        [Required]
        public string NewName { get; set; }

        [Display(Name = "新しい職位：")]
        public string NewPosition { get; set; }

        [Display(Name = "新しい入社時間：")]
        public string NewStartDate { get; set; }
    }
}