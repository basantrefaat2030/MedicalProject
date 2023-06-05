namespace MedicalProject.Infrastructure.Entities
{
    public class ContactUs : BaseData
    {
        public int ContactUsId { get; set; }
        public string? Name { get; set;}

        public string? Email { get; set;}

        public string? Phone { get; set;}

        public string? Message { get; set;}
    }
}
