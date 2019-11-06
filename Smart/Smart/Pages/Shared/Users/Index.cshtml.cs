using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Shared.Users
{
    public class UserIndexModel : PageModel
    {

        private readonly ApplicationDbContext _context;

        public UserIndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> Users { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Users = await _context.ApplicationUser
            .Include(i => i.FirstName)
            .Include(i => i.LastName)
            .AsNoTracking()
            .OrderBy(i => i.LastName)
            .ToListAsync();



        }
    }
}
