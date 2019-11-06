using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ScheduleAvailability
    {
        public int ScheduleAvailabilityId { get; set; }
        public int DayOfWeek { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<PublicSchoolClassSchedule> PublicSchoolClassSchedules { get; set; }
    }
}
