namespace MedicalProject.Infrastructure.Entities
{
    public class Category : BaseData
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
