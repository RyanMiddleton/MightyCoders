using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class PublicSchoolClassSchedule
    {
        public int PublicSchoolClassScheduleId { get; set; }
        public int StudentPublicSchoolClassId { get; set; }
        public StudentPublicSchoolClass StudentPublicSchoolClasses { get; set; }
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }
    }
}
