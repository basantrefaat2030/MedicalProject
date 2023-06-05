namespace MedicalProject.Infrastructure.Entities
{
    public class Department : BaseData
    {
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? ImageId { get; set; }

        public ICollection<DepartmentServices> DepartmentServices { get; set; } 
        public ICollection <Appointment> Appointments { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
