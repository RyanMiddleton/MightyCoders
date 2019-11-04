using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Instructors.Grading
{
    public class CreateModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public CreateModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AssessmentId"] = new SelectList(_context.Assessment, "AssessmentId", "AssessmentId");
        ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FirstName");
            return Page();
        }

        [BindProperty]
        public StudentAssessment StudentAssessment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.StudentAssessment.Add(StudentAssessment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}