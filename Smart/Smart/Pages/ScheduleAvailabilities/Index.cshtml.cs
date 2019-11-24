using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.ScheduleAvailabilities
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<ScheduleAvailability> ScheduleAvailabilities { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .OrderBy(t => t.StartTime)
                                              .OrderBy(s => s.DayOfWeek)
                                              .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetRemoveAsync(int? scheduleId)
        {
            if (scheduleId == null)
            {
                return await OnGetAsync();
            }
            var scheduleToDelete = await _db.ScheduleAvailability.SingleOrDefaultAsync(sa => sa.ScheduleAvailabilityId == scheduleId);
            if (scheduleToDelete != null)
            {
                _db.ScheduleAvailability.Remove(scheduleToDelete);
                await _db.SaveChangesAsync();
            }
            return await OnGetAsync();
        }
        
    }
}