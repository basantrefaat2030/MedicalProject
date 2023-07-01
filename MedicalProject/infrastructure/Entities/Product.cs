using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class Product : BaseData
    {
        public int ProductId { get; set; }

       public string? ProductName { get; set; }

       public string? ProductDescription { get; set; }

      public double Price { get; set; }
      public int Quantity { get; set; }

      public int? ImageId { get; set; }

        [ForeignKey("Category")]
      public int CategoryId { get; set; }
      public Category Category { get; set; }


    }
}
