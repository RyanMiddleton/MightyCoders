using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class PublicSchoolClassSchedule
    {
        public int PublicSchoolClassScheduleId { get; set; }
        [Display(Name = "Public School Class")]
        public int StudentPublicSchoolClassId { get; set; }
        public StudentPublicSchoolClass StudentPublicSchoolClasses { get; set; }
        [Display(Name = "Schedule")]
        public int ScheduleAvailabilityId { get; set; }
        public ScheduleAvailability ScheduleAvailability { get; set; }
    }
}
