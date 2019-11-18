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
        [Key]
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [Display(Name = "Points Awarded")]
        public double PointsAwarded { get; set; } 
        public string Comments { get; set; }
        [Display(Name = "Submission Timestamp")]
        public DateTime SubmissionDateTime { get; set; }
        [Display(Name = "File")]
        public int? FileId { get; set; }
        public virtual File File { get; set; }
    }
}
