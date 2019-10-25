using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ApplicantRating
    {
        [Key]
        public int ApplicantRatingId { get; set; }
        public int StudentId { get; set; }
        public int UserId { get; set; }
        public int RatingCriteriaId { get; set; }
        public int TermId { get; set; }
        public int ScoreAssigned { get; set; }
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }

    }
}
