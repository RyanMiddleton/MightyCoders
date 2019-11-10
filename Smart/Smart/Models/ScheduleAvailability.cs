using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ScheduleAvailability
    {
        public int ScheduleAvailabilityId { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<PublicSchoolClassSchedule> PublicSchoolClassSchedules { get; set; }
    }
}
