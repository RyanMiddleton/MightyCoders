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

        [Key]
        public int ClassScheduleId { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public Class Class { get; set; }
        [Display(Name = "Schedule")]
        public int ScheduleAvailabilityId { get; set; }
        [ForeignKey("ScheduleAvailabilityId")]
        public ScheduleAvailability ScheduleAvailability { get; set; }
        public int? SectionId { get; set; }
        [ForeignKey("SectionId")]
        public Section Section { get; set; }
        public virtual ICollection<StudentClassSchedule> StudentClassSchedules { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
    }
}
