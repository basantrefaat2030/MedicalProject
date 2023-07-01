namespace MedicalProject.Infrastructure.ViewModel
{
    public class ProductVM
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public double Price { get; set; }
        public int Quantity { get; set; }

        public string? CategoryName { get; set; } 
    }
}
