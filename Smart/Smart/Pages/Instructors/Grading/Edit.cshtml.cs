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

namespace Smart.Pages.Instructors.Grading
{
    public class EditModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public EditModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentAssessment StudentAssessment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? studentAssessmentId)
        {
            if (studentAssessmentId == null)
            {
                return NotFound();
            }

            StudentAssessment = await _context.StudentAssessment
                .Include(s => s.Assessment)
                .Include(s => s.Student).FirstOrDefaultAsync(m => m.AssessmentId == studentAssessmentId);

            if (StudentAssessment == null)
            {
                return NotFound();
            }
            ViewData["AssessmentId"] = new SelectList(_context.Assessment, "AssessmentId", "AssessmentId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FirstName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentAssessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentAssessmentExists(StudentAssessment.AssessmentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentAssessmentExists(int studentAssessmentId)
        {
            return _context.StudentAssessment.Any(e => e.AssessmentId == studentAssessmentId);
        }
    }
}
