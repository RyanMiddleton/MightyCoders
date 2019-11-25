using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Instructors.Assessments
{
    [Authorize(Roles = "Admin")]
    public class CopyModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public CopyModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assessment Assessment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assessment = await _context.Assessment
                .Include(a => a.Class).FirstOrDefaultAsync(m => m.AssessmentId == id);

            if (Assessment == null)
            {
                return NotFound();
            }
           ViewData["ClassId"] = await _context.Class
                .Include(c => c.Term)
                             .Select(c => new SelectListItem
                             {
                                 Value = c.ClassId.ToString(),
                                 Text = c.Course.Name + " " + c.Term.StartDate.ToString("MMMM") + " to " + c.Term.EndDate.ToString("MMMM") + " " + c.Term.EndDate.Year
                             })
                             .ToListAsync();
            //ViewData["Term"] = await _context.Term
                
            //                 .Select(t => new SelectListItem
            //                 {
            //                     Value = t.TermId.ToString(),
            //                     Text = t.StartDate.ToString("MMMM") + " to " + t.EndDate.ToString("MMMM") + " " + t.EndDate.Year
            //                 })
            //                 .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Assessment.AssessmentId = 0;

            _context.Assessment.Add(Assessment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool AssessmentExists(int id)
        {
            return _context.Assessment.Any(e => e.AssessmentId == id);
        }
    }
}
