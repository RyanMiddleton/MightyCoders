using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Assessment
    {
        //[Key]
        public int AssessmentId { get; set; }
        //O[Required]
        //[Display(Name = "Class")]
        public int ClassId { get; set; }
        //[ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PointsPossible { get; set; }
        public virtual ICollection<StudentAssessment> StudentAssessments { get; set; }
    }
}
