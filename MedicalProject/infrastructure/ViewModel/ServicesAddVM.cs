using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class ServicesAddVM
    {
        public int ServicesId { get; set; }
        [Required]
        public string ServicesName { get; set; }
        public string Description { get; set; }

        public int? ImageId { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? extention { get; set; }
    }
}
