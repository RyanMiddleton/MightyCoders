using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class StudentClass
    {
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
        [Display(Name = "Class")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
