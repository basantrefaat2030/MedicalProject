
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class DoctorServices : RepositoryBase<Doctor>, IDoctorServices
    {
        public DoctorServices(ApplicationDbContext db) : base(db)
        {
        }
    }

    public interface IDoctorServices : IRepository<Doctor>
    {

    }
}
