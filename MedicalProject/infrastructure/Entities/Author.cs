using MedicalProject.Infrastructure.Entities;
using System.Reflection.Metadata;

namespace MedicalProject.infrastructure.Entities
{
    public class Author : BaseData
    {
        public int AuthorId { get; set; }

        public string? AuthorName { get; set; }

        public string? Bio { get; set; }

        public ICollection<Blogs> Blogs { get; set; }
    }
}
