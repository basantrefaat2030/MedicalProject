
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;

namespace MedicalProject.Application.Services
{
    public class AppointmentServices : RepositoryBase<Appointment>, IAppointmentServices
    {
        public AppointmentServices(ApplicationDbContext db) : base(db)
        {
        }
    }

    public interface IAppointmentServices : IRepository<Appointment>
    {

    }
}
