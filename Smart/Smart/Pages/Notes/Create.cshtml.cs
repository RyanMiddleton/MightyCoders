using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Notes
{
    [Authorize(Roles = "Rater, Instructor, SocialWorker, Admin")]
    public class CreateModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public CreateModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "UserName");
        ViewData["NoteTypeId"] = new SelectList(_context.NoteType, "NoteTypeId", "Description");
        ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FullName");
            return Page();
        }

        [BindProperty]
        public Note Note { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Note.Add(Note);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}