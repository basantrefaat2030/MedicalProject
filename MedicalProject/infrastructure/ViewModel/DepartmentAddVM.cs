using System.ComponentModel.DataAnnotations;

namespace MedicalProject.infrastructure.ViewModel
{
    public class DepartmentAddVM
    {
        public int DepartmentId { get; set; }

        [Required]
        public string? DepartmentName { get; set; }

        //[Required]
        public string? Description { get; set; }

        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        public int? ImageId { get; set; }

        public string extention { get; set; }
        public DateTime? CreationDate { get; set; } 

    }
}
