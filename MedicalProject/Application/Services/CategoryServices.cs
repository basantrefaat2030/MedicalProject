
using MedicalProject.Application;
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using System.Linq.Expressions;

namespace MedicalProject.Application.Services
{
	public class CategoryServices : RepositoryBase<Category>, ICategoryServices
    {
        public CategoryServices(ApplicationDbContext db) : base(db)
        {

        }

        public int CategoryCount()
        {
            return _dbset.Count();
        }
    }

	public interface ICategoryServices :IRepository<Category>
	{
        int CategoryCount();
	}
}
