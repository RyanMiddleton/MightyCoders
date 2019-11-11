using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Ratings
{
    public class CreateModel : CriteriaNameModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public CreateModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        PopulateCriteriaDropDownList(_context);
        ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "FullName");
        PopulateTermDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public ApplicantRating ApplicantRating { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ApplicantRating.Add(ApplicantRating);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}