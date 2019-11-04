using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;
using Smart.Models.InstructorViewModels;

namespace Smart.Pages.Instructors.Grading
{
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public GradingIndexData GradingData { get; set; }

        public async Task OnGetAsync(int? assessmentId)
        {
            GradingData = new GradingIndexData();
            GradingData.Assessments = await _context.Assessment
                .Include(a => a.Class)
                .Include(a => a.StudentAssessments).ToListAsync();

            if (assessmentId != null)
            {
                Assessment assessment = GradingData.Assessments
                    .Where(s => s.AssessmentId == assessmentId.Value).Single();
                GradingData.StudentAssessments = assessment.StudentAssessments.ToList();
            }
        }
    }
}
