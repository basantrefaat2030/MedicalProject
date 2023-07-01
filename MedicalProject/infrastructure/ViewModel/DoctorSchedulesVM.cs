using MedicalProject.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.Infrastructure.ViewModel
{
    public class DoctorSchedulesVM
    {
        public int DoctorSchedulesId { get; set; }
        public int DoctorId { get; set; }
        public WeekDays DayId { get; set; }
        [DisplayFormat(DataFormatString = "{hh:mm}")]
        public TimeSpan StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{hh:mm}")]
        public TimeSpan EndTime { get; set; }
    }
}
