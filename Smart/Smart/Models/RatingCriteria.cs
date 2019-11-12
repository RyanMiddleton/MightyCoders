using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class RatingCriteria
    {
        [Key]
        public int RatingCriteriaId { get; set; }
        public string Description { get; set; }
        [Display(Name = "Max Score")]
        public int MaxScore { get; set; }
    }
}
