using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ClassSchedule
    {
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int ScheduleAvailabilityId { get; set; }
        public ScheduleAvailability ScheduleAvailability { get; set; }
    }
}
