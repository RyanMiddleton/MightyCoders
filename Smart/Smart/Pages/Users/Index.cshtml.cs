using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< Updated upstream
using Microsoft.EntityFrameworkCore;
using Smart.Models;
=======
>>>>>>> Stashed changes

namespace Smart.Pages.Users
{
    public class IndexModel : PageModel
    {
<<<<<<< Updated upstream
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> Users { get; set; }
        public async Task OnGetAsync(int? id)
        {
            Users = await _context.ApplicationUser
                .AsNoTracking()
                .OrderBy(i => i.LastName)
                .ToListAsync();
=======
        public void OnGet()
        {
>>>>>>> Stashed changes
        }
    }
}
