using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class ListViewModel
    {
        [Display(Name = "職位：")]
        public string Position { get; set; }
    }
}