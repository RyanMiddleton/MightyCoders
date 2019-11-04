using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Term
    {
        //[Key]
        public int TermId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeOfYear { get; set; } // may need to change this
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<ApplicantRating> ApplicantRatings { get; set; }
    }
}
