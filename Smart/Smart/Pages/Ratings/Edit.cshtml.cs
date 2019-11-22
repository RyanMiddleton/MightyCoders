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

namespace Smart.Pages.Ratings
{
    [Authorize(Roles = "Rater, Admin")]
    public class EditModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public EditModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicantRating ApplicantRating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicantRating = await _context.ApplicantRating
                .Include(a => a.ApplicationUser)
                .Include(a => a.RatingCriteria)
                .Include(a => a.Student)
                .Include(a => a.Term).FirstOrDefaultAsync(m => m.ApplicantRatingId == id);

            if (ApplicantRating == null)
            {
                return NotFound();
            }
           ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
           ViewData["RatingCriteriaId"] = new SelectList(_context.RatingCriteria, "RatingCriteriaId", "RatingCriteriaId");
           ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FirstName");
           ViewData["TermId"] = new SelectList(_context.Term, "TermId", "TermId");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ApplicantRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicantRatingExists(ApplicantRating.ApplicantRatingId))
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

        private bool ApplicantRatingExists(int id)
        {
            return _context.ApplicantRating.Any(e => e.ApplicantRatingId == id);
        }
    }
}
