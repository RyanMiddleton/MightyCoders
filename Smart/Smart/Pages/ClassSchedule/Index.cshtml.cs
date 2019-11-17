using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                                 Text = t.StartDate.ToString("MMMM") + " to " + t.EndDate.ToString("MMMM") + " " + t.EndDate.Year
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
                                   .Where(c => c.Course.IsTaughtHere == true)
                                   .ToListAsync();
                ClassSelectList = Classes.ConvertAll(c =>
                                         {
                                             return new SelectListItem()
                                             {
                                                 Value = c.ClassId.ToString(),
                                                 Text = c.Course.Name
                                             };
                                         });
                ClassSelectList.Insert(0, new SelectListItem { Text = "-- Select Class --", Value = null });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostScheduleClass(int? classId)
        {
            if (classId == null)
            {
                return await OnGetAsync(null);
            }
            foreach (var s in ScheduleAvailabilities)
            {
                if (s.Selected)
                {
                    if (!_db.ClassSchedule.Any(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == s.ScheduleAvailabilityId))
                    {
                        var newClassSchedule = new Models.ClassSchedule()
                        {
                            ClassId = (int)classId,
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

        public async Task<IActionResult> OnGetRemove(int? classId, int? scheduleId)
        {
            if (classId == null || scheduleId == null)
            {
                return await OnGetAsync(null);
            }
            var classScheduleToDelete = _db.ClassSchedule.FirstOrDefault(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == scheduleId);
            if (classScheduleToDelete == null)
            {
                return await OnGetAsync(null);
            }
            _db.ClassSchedule.Remove(classScheduleToDelete);
            await _db.SaveChangesAsync();
            int termIdToRedirect = _db.Class.FirstOrDefault(c => c.ClassId == classId).TermId;
            return await OnGetAsync(termIdToRedirect);
        }
    }
}