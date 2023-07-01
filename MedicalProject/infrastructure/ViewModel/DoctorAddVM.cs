using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class DoctorAddVM
    {
        public int DoctorId { get; set; }
        [Required]
        public string? DoctorName { get; set; }
        public string? Summary { get; set; }
        [Required]
        public string? Education { get; set; }
        [Required]
        public string? Degree { get; set; }

        public string? Address { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter a Valid Email")]
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Phone { get; set; }
        public int? ImageId { get; set; }

        public string? extention { get; set; }
        public int DepartmentId { get; set; }

        public SelectList? Departmentlist { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}
