using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class DepartmentServices : RepositoryBase<Department> , IDepartmentServices
    {
        public DepartmentServices(ApplicationDbContext db) : base(db)
        {
        }
    }

    public interface IDepartmentServices : IRepository<Department>
    {

    }
}
