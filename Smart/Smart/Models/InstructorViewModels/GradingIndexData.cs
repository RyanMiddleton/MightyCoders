using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.InstructorViewModels
{
    public class GradingIndexData
    {
        public IEnumerable<Assessment> Assessments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<StudentAssessment> StudentAssessments { get; set; }
        public IEnumerable<Class> Classes { get; set; }
    }
}
