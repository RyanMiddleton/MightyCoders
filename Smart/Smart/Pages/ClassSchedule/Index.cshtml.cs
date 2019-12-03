using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Pages.ClassSchedule
{
    [Authorize(Roles = "Instructor, Admin")]
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
        public List<SelectListItem> SectionSelectList { get; set; }

        [BindProperty]
        public List<SelectListItem> Terms { get; set; }

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
            ScheduleAvailabilities = await _db.ScheduleAvailability
                                              .Where(sa => sa.TermId == termId)
                                              .OrderBy(t => t.StartTime)
                                              .OrderBy(s => s.DayOfWeek)
                                              .Include(sa => sa.ClassSchedules)
                                              .ToListAsync();
            Classes = await _db.Class
                               .Include(c => c.Course)
                               .Include(c => c.ClassSchedules)
                                    .ThenInclude(cs => cs.Section)
                               .Where(t => t.TermId == termId)
                               .Where(c => c.Course.IsTaughtHere == true)
                               .OrderBy(c => c.Course.Name)
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
            SectionSelectList = await _db.Section
                                         .Select(s => new SelectListItem
                                         {
                                             Value = s.SectionId.ToString(),
                                             Text = s.Name
                                         })
                                         .ToListAsync();
            SectionSelectList.Insert(0, new SelectListItem { Text = "-- Select Section --", Value = null });
            return Page();
        }

        public async Task<IActionResult> OnPostScheduleClass(int? classId, int? sectionId)
        {
            if (classId == null)
            {
                return await OnGetAsync(null);
            }
            if (sectionId == null)
            {
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
            }
            else
            {
                foreach (var s in ScheduleAvailabilities)
                {
                    if (s.Selected)
                    {
                        if (!_db.ClassSchedule.Any(cs => cs.ClassId == classId && cs.ScheduleAvailabilityId == s.ScheduleAvailabilityId && cs.SectionId == sectionId))
                        {
                            var newClassSchedule = new Models.ClassSchedule()
                            {
                                ClassId = (int)classId,
                                ScheduleAvailabilityId = s.ScheduleAvailabilityId,
                                SectionId = sectionId
                            };
                            _db.ClassSchedule.Add(newClassSchedule);
                        }
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