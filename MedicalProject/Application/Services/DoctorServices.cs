
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class DoctorServices : RepositoryBase<Doctor>, IDoctorServices
    {
        public DoctorServices(ApplicationDbContext db) : base(db)
        {
        }

        public int DoctorCount()
        {
            return _dbset.Count();
        }
    }

    public interface IDoctorServices : IRepository<Doctor>
    {
        int DoctorCount();
    }
}
