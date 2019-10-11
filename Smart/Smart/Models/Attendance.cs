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
        public int Id { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }
        [ForeignKey("TermId")]
        public virtual Term Term { get; set; }
        public bool Attended { get; set; }
        public DateTime Date { get; set; }
    }
}
