using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class Doctor : BaseData
    {
        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }    

        public string?  Summary{ get; set; } 
        public string? Education { get; set; }
        public string? Degree { get; set; }

        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? ImageId { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<DoctorSchedules> DoctorSchedules { get; set; }

    }
}
