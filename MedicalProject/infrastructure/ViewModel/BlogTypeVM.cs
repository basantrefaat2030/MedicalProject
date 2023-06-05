
using MedicalProject.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class BlogTypeVM
    {
      public int BlogTypeId { get; set; }

        [Required]
      public string? BlogTypeName { get; set; }
    }
}
