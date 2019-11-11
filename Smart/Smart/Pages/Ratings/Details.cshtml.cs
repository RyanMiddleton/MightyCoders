using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Ratings
{
    public class DetailsModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public DetailsModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
