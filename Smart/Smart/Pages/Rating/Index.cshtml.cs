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

namespace Smart.Pages.Rating
{
    public class IndexModel : PageModel
    {
        #region Contructor
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
      
        #endregion

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
        
        }
    }
}