
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

        public DoctorSchedules CheckByDay(WeekDays dayId , int docId)
        {
            return _dbset.FirstOrDefault(a => a.DayId == dayId && a.IsDeleted != true && a.DoctorId == docId);
        }
    }


    public interface IDoctorSchedulesServices : IRepository<DoctorSchedules>
    {
        DoctorSchedules CheckByDay(WeekDays dayId , int docId);
    }

}
