
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class BlogTypeAdd
    {
        public int BlogTypeId { get; set; }

        [Required]
        public string? BlogTypeName { get; set; }

        public DateTime? CreationDate { get; set; } = DateTime.Now;

    }
}
