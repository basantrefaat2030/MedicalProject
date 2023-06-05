namespace MedicalProject.Infrastructure.Entities
{
    public class Attachments :BaseData
    {
        public int AttachmentsId { get; set; }
        public int? TypeId { get; set; }
        public string Title { get; set; }
    }
}
