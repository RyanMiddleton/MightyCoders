using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [BindProperty]
        public int ClassID { get; set; }
        public GradingIndexData GradingData { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public async Task OnGetAsync(int? assessmentId)
        {
            GradingData = new GradingIndexData();
            GradingData.Classes = await _context.Class.ToListAsync();
            GradingData.StudentAssessments = await _context.StudentAssessment.ToListAsync();
            GradingData.Assessments = await _context.Assessment.ToListAsync();
            GradingData.Students = await _context.Student.ToListAsync();

            Classes = _context.Class.Select(c =>
                                            new SelectListItem
                                            {
                                                Value = c.ClassId.ToString(),
                                                Text = c.Course.Name.ToString()
                                            }).ToList();
            //.Include(a => a.Assessments)
            //.Include(a => a.Students)
            //.Include(a => a.StudentAssessments).ToListAsync();

            if (ClassID != 0)
            {
                Assessment assessment = GradingData.Assessments
                    .Where(s => s.AssessmentId == assessmentId.Value).Single();
                GradingData.StudentAssessments = assessment.StudentAssessments.ToList();
            }
        }
    }
}
