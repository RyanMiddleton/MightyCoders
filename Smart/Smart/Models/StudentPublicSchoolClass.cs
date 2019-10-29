using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class StudentPublicSchoolClass
    {
        public int StudentPublicSchoolClassId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public string CourseName { get; set; }
    }
}
