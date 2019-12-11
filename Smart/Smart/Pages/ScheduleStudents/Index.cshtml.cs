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
        [BindProperty]
        public int? StudentId { get; set; }
        [BindProperty]
        public int? TermId { get; set; }
        [BindProperty]
        public List<SelectListItem> StudentsSelectList { get; set; }
        public List<Class> Classes { get; set; }
        [BindProperty]
        public List<Models.ClassSchedule> ClassSchedules { get; set; }
        public List<Student> StudentPublicClasses { get; set; }
        public List<SelectListItem> Terms { get; set; }

        public async Task<IActionResult> OnGetAsync(int? termId, int? studentId, string shift = null)
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
            var selectedTerm = Terms.Where(t => t.Value == termId.ToString()).FirstOrDefault();
            selectedTerm.Selected = true;
            TermId = termId;
            Students = await _db.Student
                                .Include(s => s.StudentStatus)
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

            if (studentId != null)
            {
                var selectedStudent = StudentsSelectList.Where(s => s.Value == studentId.ToString()).FirstOrDefault();
                if (shift == null)
                {
                    selectedStudent.Selected = true;
                    StudentId = studentId;           
                }
                else if (shift == "prev")
                {
                    var index = StudentsSelectList.IndexOf(selectedStudent);
                    if (index > 1)
                    {
                        StudentsSelectList[index - 1].Selected = true;
                        StudentId = Int32.Parse(StudentsSelectList[index - 1].Value);
                    }
                    else
                    {
                        selectedStudent.Selected = true;
                        StudentId = studentId;           
                    }
                }
                else if (shift == "next")
                {
                    var index = StudentsSelectList.IndexOf(selectedStudent);
                    if (index < StudentsSelectList.Count - 1)
                    {
                        StudentsSelectList[index + 1].Selected = true;
                        StudentId = Int32.Parse(StudentsSelectList[index + 1].Value);
                    }
                    else
                    {
                        selectedStudent.Selected = true;
                        StudentId = studentId;           
                    }
                }
                Student student = Students.Where(s => s.StudentId == StudentId).FirstOrDefault();
                ClassSchedules = await _db.ClassSchedule
                                   .Include(cs => cs.ScheduleAvailability)
                                   .Include(cs => cs.Section)
                                   .Include(cs => cs.Class)
                                       .ThenInclude(c => c.Course)
                                   .Where(cs => cs.Class.TermId == termId && cs.Class.Course.IsTaughtHere == true 
                                        && (cs.Class.Course.Name == "ENG" + (student.EnglishLevel + 1).ToString() || cs.Class.Course.Name == "IT" + (student.EnglishLevel + 1).ToString()))
                                   .Include(c => c.Class.ApplicationUser)
                                   .OrderBy(c => c.ScheduleAvailability.StartTime)
                                   .OrderBy(c => c.ScheduleAvailability.DayOfWeek)
                                   .ToListAsync();
                foreach (var cs in ClassSchedules)
                {
                    if(await _db.StudentClassSchedule.AnyAsync(scs => scs.ClassScheduleId == cs.ClassScheduleId && scs.StudentId == StudentId))
                    {
                        cs.Selected = true;
                    }
                }
            }
            ModelState.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostScheduleStudent(string submit)
        {
            if (StudentId == null || ClassSchedules == null)
            {
                return await OnGetAsync(null, null, null);
            }
            foreach (var s in ClassSchedules)
            {
                if (s.Selected)
                {
                    if (!_db.StudentClassSchedule.Any(scs => scs.ClassScheduleId == s.ClassScheduleId && scs.StudentId == StudentId))
                    {
                        var newStudentClassSchedule = new StudentClassSchedule()
                        {
                            StudentId = (int)StudentId,
                            ClassScheduleId = s.ClassScheduleId
                        };
                        _db.StudentClassSchedule.Add(newStudentClassSchedule);
                    }
                }
                else
                {
                    StudentClassSchedule studentClassSchedule = await _db.StudentClassSchedule.SingleOrDefaultAsync(scs => scs.ClassScheduleId == s.ClassScheduleId 
                                                                                                                    && scs.StudentId == StudentId);
                    if (studentClassSchedule != null)
                    {
                        _db.StudentClassSchedule.Remove(studentClassSchedule);
                    }
                }
            }
            await _db.SaveChangesAsync();
            if (submit == "prev")
            {
                return await OnGetAsync(TermId, StudentId, "prev");
            }
            if (submit == "next")
            {
                return await OnGetAsync(TermId, StudentId, "next");
            }
            return await OnGetAsync(TermId, StudentId, null);
        }

    }
}