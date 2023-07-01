
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class ServicesVM
    {
        public int ServicesId { get; set; }
        public string ServicesName { get; set; }
        
        public string Description { get; set; }
    }
}
