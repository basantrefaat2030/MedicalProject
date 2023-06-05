namespace MedicalProject.Infrastructure.Entities
{
    public class Services : BaseData
    {
        public int ServicesId { get; set; } 
        public string? ServicesName { get; set; }
        public string? Description { get; set; }

        public int ImageId { get;set; }
    }
}
