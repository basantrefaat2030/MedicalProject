
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class BlogTypeServices : RepositoryBase<BlogType> , IBlogTypeServices
    {
        public BlogTypeServices(ApplicationDbContext db) : base(db)
        {
        }
    }

    public interface IBlogTypeServices : IRepository<BlogType>
    {

    }

}
