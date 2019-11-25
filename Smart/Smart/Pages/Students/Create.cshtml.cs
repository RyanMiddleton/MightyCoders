using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Students
{
    [Authorize(Roles = "Instructor, Admin")]
    public class CreateModel : StatusNameModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public CreateModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateApplicantStatusDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync(Student student)
        {
            //var emptyStudent = new Student();
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] pic = null;
                    using (var fs = files[0].OpenReadStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            pic = ms.ToArray();
                        }
                    }
                   student.Photo = pic;
                }
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}