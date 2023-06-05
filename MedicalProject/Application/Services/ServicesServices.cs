using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class ServicesServices : RepositoryBase<MedicalProject.Infrastructure.Entities.Services> , IServicesServices
    {
        public ServicesServices(ApplicationDbContext db) : base(db)
        {
        }


        
    }

    public interface IServicesServices : IRepository<MedicalProject.Infrastructure.Entities.Services>
    {

    }
}
