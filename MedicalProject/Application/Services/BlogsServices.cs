
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class BlogsServices : RepositoryBase<Blogs>, IBlogsServices
    {
        public BlogsServices(ApplicationDbContext db) : base(db)
        {
        }
    }

    public interface IBlogsServices : IRepository<Blogs>
    {

    }
}
