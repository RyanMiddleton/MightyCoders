using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}
