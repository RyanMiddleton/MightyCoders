using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get;set; }

        public async Task OnGetAsync()
        {
            Note = await _context.Note
                .OrderBy(n => n.Student.LastName)
                .Include(n => n.ApplicationUser)
                .Include(n => n.NoteType)
                .Include(n => n.Student).ToListAsync();
        }
    }
}
