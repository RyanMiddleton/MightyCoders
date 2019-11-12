using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class StudentPublicSchoolClass
    {
        public int StudentPublicSchoolClassId { get; set; }
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
    }
}
