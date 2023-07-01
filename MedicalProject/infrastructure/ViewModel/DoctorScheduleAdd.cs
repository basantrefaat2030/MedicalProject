using MedicalProject.Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MedicalProject.infrastructure.ViewModel
{
    public class DoctorScheduleAdd
    {
        public int DoctorSchedulesId { get; set; }

        public int DoctorId { get; set; }
        [Required]
        public WeekDays DayId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{hh:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan EndTime { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

      
    }
}
