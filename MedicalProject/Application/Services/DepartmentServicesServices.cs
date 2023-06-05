
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class DepartmentServicesServices : RepositoryBase<DepartmentServices> , IDepartmentServicesServices
    {
        public DepartmentServicesServices(ApplicationDbContext db) : base(db)
        {
        }
    }


    public interface IDepartmentServicesServices : IRepository<DepartmentServices>
    {

    }
}
