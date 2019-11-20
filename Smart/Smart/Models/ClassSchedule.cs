using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ClassSchedule
    {

        [Display(Name = "Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
        [Display(Name = "Schedule")]
        public int ScheduleAvailabilityId { get; set; }
        public ScheduleAvailability ScheduleAvailability { get; set; }
    }
}
