

using System.ComponentModel.DataAnnotations;

namespace MedicalProject.infrastructure.ViewModel
{
    public class CategoryAddVM
    {
        public int CategoryId { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;
    }
}
