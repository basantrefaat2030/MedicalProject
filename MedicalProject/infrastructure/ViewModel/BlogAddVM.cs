using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class BlogAddVM
    {
        public int BlogsId { get; set; }
        [Required]
        public string BlogsName { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public string Descriptions { get; set; }

        public int? ImageId { get; set; }

        public int BlogTypeId { get; set; }
        public DateTime? CreationDate { get; set; }

        public string? extention { get; set; }
        public SelectList? BlogTypeList { get; set; }

    }
}
