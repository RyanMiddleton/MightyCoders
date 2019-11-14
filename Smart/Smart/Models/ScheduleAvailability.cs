using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ScheduleAvailability
    {
        [Key]
        public int ScheduleAvailabilityId { get; set; }
        [Display(Name = "Day of the Week")]
        public int DayOfWeek { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<PublicSchoolClassSchedule> PublicSchoolClassSchedules { get; set; }
    }
}
