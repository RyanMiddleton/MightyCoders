using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models.InstructorViewModels
{
    public class RatingDashboardViewModel
    {
        public List<Student> Students { get; set; }
        //public Term SelectedTerm { get; set; }
        public List<RatingCriteria> AvailableCriterium { get; set; }
        public string CurrentUserId { get; set; }
    }
}
