﻿
using MedicalProject.Application;
using MedicalProject.Application.Interfaces;
using MedicalProject.Infrastructure.Entities;
using System.Linq.Expressions;

namespace MedicalProject.Application.Services
{
	public class DoctorSchedulesServices : RepositoryBase<DoctorSchedules> , IDoctorSchedulesServicesServices
    {
        public DoctorSchedulesServices(ApplicationDbContext db) : base(db)
        {

        }

    }


    public interface IDoctorSchedulesServicesServices : IRepository<DoctorSchedules>
    {

    }

}
