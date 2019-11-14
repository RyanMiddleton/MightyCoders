using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Attendance
    {
        [Key]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Time In")]
        public DateTime TimeIn { get; set; }
        [Required]
        [Display(Name = "Attendance Status")]
        public int AttendanceStatusId { get; set; }
        [ForeignKey("AttendanceStatusId")]
        public AttendanceStatus AttendanceStatus { get; set; }
    }
}
