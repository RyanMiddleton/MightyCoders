using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.ScheduleStudents
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Student> Students { get; set; }
        public List<SelectListItem> StudentsSelectList { get; set; }
        public List<Class> Classes { get; set; }
        public List<Models.ClassSchedule> ClassSchedules { get; set; }
        public List<Student> StudentPublicClasses { get; set; }
        public List<SelectListItem> Terms { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId, int? studentId)
        {
            Terms = await _db.Term
                             .Select(t => new SelectListItem
                             {
                                 Value = t.TermId.ToString(),
                                 Text = t.StartDate.ToString("MMMM") + " to " + t.EndDate.ToString("MMMM") + " " + t.EndDate.Year
                             })
                             .ToListAsync();
            Terms.Insert(0, new SelectListItem { Text = "-- Select Term --", Value = null });
            Students = await _db.Student
                                .Where(s => s.StudentStatus.Description == "Student")
                                .OrderBy(s => s.LastName)
                                .ToListAsync();
            StudentsSelectList = Students.ConvertAll(s =>
                                {
                                    return new SelectListItem()
                                    {
                                        Value = s.StudentId.ToString(),
                                        Text = s.LastName + ", " + s.FirstName
                                    };
                                });
            StudentsSelectList.Insert(0, new SelectListItem { Text = "-- Select Student --", Value = null });

            if (termId != null)
            {
                var selectedTerm = Terms.Where(t => t.Value == termId.ToString()).FirstOrDefault();
                selectedTerm.Selected = true;
            }
            if (studentId != null)
            {
                var selectedStudent = StudentsSelectList.Where(s => s.Value == studentId.ToString()).FirstOrDefault();
                selectedStudent.Selected = true;
            }
            if (termId != null && studentId != null)
            {
                Student student = Students.Where(s => s.StudentId == studentId).FirstOrDefault();
                ClassSchedules = await _db.ClassSchedule
                                   .Include(cs => cs.ScheduleAvailability)
                                   .Include(cs => cs.Class)
                                       .ThenInclude(c => c.Course)
                                   .Where(cs => cs.Class.TermId == termId && cs.Class.Course.IsTaughtHere == true 
                                        && (cs.Class.Course.Name == "ENG" + (student.EnglishLevel + 1).ToString() || cs.Class.Course.Name == "IT" + (student.EnglishLevel + 1).ToString()))
                                   .Include(c => c.Class.ApplicationUser)
                                   .OrderBy(c => c.ScheduleAvailability.StartTime)
                                   .OrderBy(c => c.ScheduleAvailability.DayOfWeek)
                                   .ToListAsync();
            }
            return Page();
        }
    }
}