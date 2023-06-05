using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class Blogs : BaseData
    {
        public int BlogsId { get; set; }
        public string BlogsName { get; set; }
        public string ShortDesc { get; set; }

        public string Descriptions { get; set; }

        public int ImageId { get; set; }

        [ForeignKey("BlogType")]
        public int BlogTypeId { get; set; }

        public BlogType BlogType { get; set; }
    }
}
