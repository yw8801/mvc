using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class DetailViewModel
    {
        [Display(Name = "社員ID：")]
        public string Id { get; set; }

        [Display(Name = "名前：")]
        public string Name { get; set; }

        [Display(Name = "職位：")]
        public string Position { get; set; }

        [Display(Name = "入社時間：")]
        public string StartDate { get; set; }
    }
}