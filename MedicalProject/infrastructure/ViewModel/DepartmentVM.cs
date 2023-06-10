
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.infrastructure.ViewModel
{
    public class DepartmentVM
    {
        public int DepartmentId { get; set; }
      
        public string? DepartmentName { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }
       
        public string? Email { get; set; }
      
        public string? Phone { get; set; }
        //public int? ImageId { get; set; }

    }
}
