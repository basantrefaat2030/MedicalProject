
using MedicalProject.Application;
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace ApplicationWithCodeFirst.Application.Services
{
	public class ProductServices : RepositoryBase<Product>, IProductServices
    {
        public ProductServices(ApplicationDbContext db) : base(db)
        {

        }

        public int ProductCount()
        {
           return _dbset.Count();
        }
    }
	public interface IProductServices : IRepository<Product>
	{
        int ProductCount();
	}
}
