using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Students
{
    [Authorize(Roles = "Instructor, Admin")]
    public class EditModel : StatusNameModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public EditModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student
                .Include(s => s.StudentStatus)
                .FirstOrDefaultAsync(m => m.StudentId == id);

            if (Student == null)
            {
                return NotFound();
            }
            PopulateStatusDropDownList(_context);
            return Page();
        }

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
                _context.Student.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
