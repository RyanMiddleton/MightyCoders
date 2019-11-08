using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ApplicantRating
    {
        [Key]
        public int ApplicantRatingId { get; set; }
        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        [Display(Name = "Rating Criteria")]
        public int RatingCriteriaId { get; set; }
        public RatingCriteria RatingCriteria { get; set; }
        [Required]
        [Display(Name = "Term")]
        public int TermId { get; set; }
        public virtual Term Term { get; set; }
        public int ScoreAssigned { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
    }
}
