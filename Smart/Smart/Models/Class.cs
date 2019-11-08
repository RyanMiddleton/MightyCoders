using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public virtual Term Term { get; set; }
        [Display(Name = "Instructor")]
        public string InstructorUserId { get; set; }
        [ForeignKey("InstructorUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int Capacity { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
    }
}
