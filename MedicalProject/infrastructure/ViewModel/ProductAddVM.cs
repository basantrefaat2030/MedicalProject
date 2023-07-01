using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class ProductAddVM
    {
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int? ImageId { get; set; }
        public int CategoryId { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

        public SelectList? CategoryList { get; set; }
        public string? extention { get; set; }
    }
}
