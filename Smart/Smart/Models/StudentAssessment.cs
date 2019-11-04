using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class StudentAssessment
    {
        [Key]
        [Required]
        [Display(Name = "Assessment")]
        public int AssessmentId { get; set; }
        public virtual Assessment Assessment { get; set; }
        //[Key]
        //[Required]
        public int StudentId { get; set; }
        //[ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        public double PointsAwarded { get; set; } 
        public string Comments { get; set; }
    }
}
