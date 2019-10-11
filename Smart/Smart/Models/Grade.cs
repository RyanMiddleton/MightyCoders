using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("AssessmentId")]
        public virtual Assessment Assessment { get; set; }
        public double Score { get; set; }
    }
}
