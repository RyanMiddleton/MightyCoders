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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Smart.Pages.ClassSchedule
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
        public List<SelectListItem> Classes { get; set; }
        [BindProperty]
        public List<SelectListItem> Terms { get; set; }
        [BindProperty]
        public List<Selected> SelectedScheduleIds { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .OrderBy(s => s.DayOfWeek)
                                              .ToListAsync();
            SelectedScheduleIds = new List<Selected>();
            foreach (var sa in ScheduleAvailabilities)
            {
                SelectedScheduleIds.Add(new Selected { Id = sa.ScheduleAvailabilityId, IsSelected = false });
            }

            Terms = await _db.Term
                             .Select(t => new SelectListItem
                             {
                                 Value = t.TermId.ToString(),
                                 Text = t.Description
                             })
                             .ToListAsync();
                Terms.Insert(0, new SelectListItem { Text = "-- Select Term --", Value = null });
            if (termId != null)
            {

                var selectedTerm = Terms.Where(t => t.Value == termId.ToString()).First();
                selectedTerm.Selected = true;
                Classes = await _db.Class
                                   .Include(c => c.Course)
                                   .Include(c => c.ClassSchedules)
                                   .Where(t => t.TermId == termId)
                                   .Select(c => new SelectListItem
                                   {
                                       Value = c.ClassId.ToString(),
                                       Text = c.Course.Name
                                   })
                                   .ToListAsync();

            }
            return Page();
        }

        public async Task<IActionResult> OnPostScheduleClass(int classId)
        {
            foreach (var s in SelectedScheduleIds)
            {
                if (s.IsSelected)
                {
                    if (!_db.ClassSchedule.Any(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == s.Id))
                    {
                        var newClassSchedule = new Models.ClassSchedule()
                        {
                            ClassId = classId,
                            ScheduleAvailabilityId = s.Id
                        };
                        _db.ClassSchedule.Add(newClassSchedule);
                    }
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
