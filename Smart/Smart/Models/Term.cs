﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Time of Year")]
        public int TimeOfYear { get; set; } 
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<ApplicantRating> ApplicantRatings { get; set; }
        public virtual ICollection<ScheduleAvailability> ScheduleAvailabilities { get; set; }

      
    }
}
