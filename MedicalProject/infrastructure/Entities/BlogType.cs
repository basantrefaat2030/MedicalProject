namespace MedicalProject.Infrastructure.Entities
{
    public class BlogType : BaseData
    {
        public int BlogTypeId { get; set; }
        public string? BlogTypeName { get; set; }    

        public ICollection<Blogs> Blogs { get; set; }
    }
}
