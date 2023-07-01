using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalProject.Infrastructure.Entities
{
    public class DoctorSchedules : BaseData
    {
        public int DoctorSchedulesId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public WeekDays DayId {  get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Doctor Doctor { get; set; }


    }

    public enum WeekDays
    {
        Saturday = 1,
        Sunday = 2,
        Monday = 3,
        Tuesday = 4,
        Wednesday = 5,
        Thursday = 6,
        Friday = 7,
    }
}
