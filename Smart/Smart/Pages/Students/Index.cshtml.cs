﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;
using Smart.Utility;

namespace Smart.Pages.Students
{

    [Authorize(Roles = "Instructor, Admin")]
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; }

        
        public async Task OnGetAsync()
        {
            Student = await _context.Student
                .OrderBy(s=> s.LastName)
                .Include(s => s.StudentStatus).ToListAsync();
        }
    }
}