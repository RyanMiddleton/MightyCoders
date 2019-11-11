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
        public List<SelectListItem> ClassSelectList { get; set; }
        public List<Class> Classes { get; set; }
        [BindProperty]
        public List<SelectListItem> Terms { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? termId)
        {
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .OrderBy(t => t.StartTime)
                                              .OrderBy(s => s.DayOfWeek)
                                              .ToListAsync();
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
                                   .ToListAsync();
                ClassSelectList = Classes.ConvertAll(c =>
                                         {
                                              return new SelectListItem()
                                              {
                                                  Value = c.ClassId.ToString(),
                                                  Text = c.Course.Name
                                              };
                                         });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostScheduleClass(int classId)
        {
            foreach (var s in ScheduleAvailabilities)
            {
                if (s.Selected)
                {
                    if (!_db.ClassSchedule.Any(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == s.ScheduleAvailabilityId))
                    {
                        var newClassSchedule = new Models.ClassSchedule()
                        {
                            ClassId = classId,
                            ScheduleAvailabilityId = s.ScheduleAvailabilityId
                        };
                        _db.ClassSchedule.Add(newClassSchedule);
                    }
                }
            }
            await _db.SaveChangesAsync();
            int termIdToRedirect = _db.Class.FirstOrDefault(c => c.ClassId == classId).TermId;
            return await OnGetAsync(termIdToRedirect);
        }

        public async Task<IActionResult> OnGetRemove(int classId, int scheduleId)
        {
            var classScheduleToDelete = _db.ClassSchedule.FirstOrDefault(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == scheduleId);
            _db.ClassSchedule.Remove(classScheduleToDelete);
            await _db.SaveChangesAsync();
            int termIdToRedirect = _db.Class.FirstOrDefault(c => c.ClassId == classId).TermId;
            return await OnGetAsync(termIdToRedirect);
        }
    }
}
