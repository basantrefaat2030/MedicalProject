
using MedicalProject.Application;
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using System.Linq.Expressions;

namespace MedicalProject.Application.Services
{
	public class DoctorSchedulesServices : RepositoryBase<DoctorSchedules> , IDoctorSchedulesServices
    {
        public DoctorSchedulesServices(ApplicationDbContext db) : base(db)
        {

        }

    }


    public interface IDoctorSchedulesServices : IRepository<DoctorSchedules>
    {

    }

}
