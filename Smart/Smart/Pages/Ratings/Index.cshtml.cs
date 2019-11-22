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
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicantRating> ApplicantRating { get; set; }

        public async Task OnGetAsync()
        {
            ApplicantRating = await _context.ApplicantRating
                .OrderBy(a => a.Student.LastName)
                .Include(a => a.ApplicationUser)
                .Include(a => a.RatingCriteria)
                .Include(a => a.Student)
                .Include(a => a.Term).ToListAsync();
        }
    }
}