using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Utility;
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
        [BindProperty]
        public ScheduleAvailability ScheduleAvailability { get; set; }
        public List<SelectListItem> DaysOfWeek { get; set; }
        [BindProperty]
        public List<SelectListItem> Terms { get; set; }
        public int TermId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            var terms = await _db.Term
                                 .OrderBy(t => t.StartDate)
                                 .ToListAsync();
            if (termId == null)
            {
                // default to the next term
                termId = terms.Where(t => t.StartDate > DateTime.Now).First().TermId;
            }
            Terms = terms.ConvertAll(t =>
                             {
                                 return new SelectListItem()
                                 {
                                     Value = t.TermId.ToString(),
                                     Text = t.StartDate.ToString("MMMM") + " to " + t.EndDate.ToString("MMMM") + " " + t.EndDate.Year
                                 };
                             });
            var selectedTerm = Terms.Where(t => t.Value == termId.ToString()).First();
            selectedTerm.Selected = true;
            TermId = (int)termId;
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .Where(sa => sa.TermId == termId)
                                              .OrderBy(t => t.StartTime)
                                              .OrderBy(s => s.DayOfWeek)
                                              .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int termId)
        {
            if (ModelState.IsValid)
            {
                var scheduleToAdd = await _db.ScheduleAvailability.SingleOrDefaultAsync(sa => sa.DayOfWeek == ScheduleAvailability.DayOfWeek 
                                                                                        && sa.StartTime == ScheduleAvailability.StartTime 
                                                                                        && sa.EndTime == ScheduleAvailability.EndTime
                                                                                        && sa.TermId == termId);
                if (scheduleToAdd == null)
                {
                    _db.ScheduleAvailability.Add(ScheduleAvailability);
                    await _db.SaveChangesAsync();
                }
            }
            return await OnGetAsync(termId);
        }

        public async Task<IActionResult> OnGetRemoveAsync(int? scheduleId)
        {
            if (scheduleId == null)
            {
                return await OnGetAsync(null);
            }
            var scheduleToDelete = await _db.ScheduleAvailability.SingleOrDefaultAsync(sa => sa.ScheduleAvailabilityId == scheduleId);
            if (scheduleToDelete != null)
            {
                var termId = scheduleToDelete.TermId;
                _db.ScheduleAvailability.Remove(scheduleToDelete);
                await _db.SaveChangesAsync();
                return await OnGetAsync(termId);
            }
            return await OnGetAsync(null);
        }
    }
}