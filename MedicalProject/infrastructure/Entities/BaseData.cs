namespace MedicalProject.Infrastructure.Entities
{
    public class BaseData
    {
        public bool? IsDeleted { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}
