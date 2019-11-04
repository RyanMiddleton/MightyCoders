using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public DetailsModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
                .Include(s => s.StudentStatus).FirstOrDefaultAsync(m => m.StudentId == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
