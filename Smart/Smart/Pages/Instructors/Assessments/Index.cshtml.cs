using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Instructors.Assessments
{
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Assessment> Assessment { get;set; }

        public async Task OnGetAsync()
        {
            Assessment = await _context.Assessment
                .Include(a => a.Class)
                .Include(a => a.Class.Term)
                .Include(a => a.Class.Course).ToListAsync();
        }
    }
}
