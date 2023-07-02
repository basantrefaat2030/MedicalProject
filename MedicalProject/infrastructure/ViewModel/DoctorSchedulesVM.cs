
using MedicalProject.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class DoctorSchedulesVM
    {
        public int DoctorId { get; set; }

        public List<ScheduleVm> SchedulesList { get; set; }
    }
}
