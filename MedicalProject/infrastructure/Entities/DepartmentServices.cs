using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class DepartmentServices : BaseData
    { 
        public int DepartmentServicesId { get; set; }

        public string DepartmentServicesName { get; set; }

        public double Price { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
