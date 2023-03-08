using System.ComponentModel.DataAnnotations;

namespace XSManager.Models
{
    public class EmployeeModel
    {
        [Key]
        [MaxLength(10)]
        public string Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        [MaxLength(100)]
        public string StartDate { get; set; }
    }
}