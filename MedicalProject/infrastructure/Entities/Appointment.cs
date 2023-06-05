using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class Appointment : BaseData
    {
        public int? AppointmentId { get; set; }
        public string? AppointmentName { get; set; }

        public string? Email { get; set; }

        public DateTime AppointmentDate { get; set;}

        public string? Note { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
