
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using NuGet.Protocol.Core.Types;

namespace MedicalProject.Application.Services
{
    public class BlogTypeServices : RepositoryBase<BlogType> , IBlogTypeServices
    {
        private ApplicationDbContext _db;
        public BlogTypeServices(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public IQueryable<BlogType> GetAllBlogType()
        //{
        //   var BlogType =  _db.BlogTypes.Where(a => a.IsDeleted != false);

        //    return BlogType;
        //}
    }

    public interface IBlogTypeServices : IRepository<BlogType>
    {
        //IQueryable<BlogType> GetAllBlogType();
    }

}
