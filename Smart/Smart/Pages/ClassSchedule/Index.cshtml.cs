using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Utility;
using Smart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Smart.Pages.ClassSchedule
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ScheduleAvailability> ScheduleAvailabilities { get; set; }
        public List<SelectListItem> Classes { get; set; }
        public async Task OnGetAsync()
        {
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .OrderBy(s => s.DayOfWeek)
                                              .ToListAsync();
            Classes = await _db.Class
                               .Include(c => c.Course)
                               .Include(c => c.ClassSchedules)
                               .Select(c => new SelectListItem
                               {
                                   Value = c.ClassId.ToString(),
                                   Text = c.Course.Name
                               })
                               .ToListAsync();
        }
    }
}
