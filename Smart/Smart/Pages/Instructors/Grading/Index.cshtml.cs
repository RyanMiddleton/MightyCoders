using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Smart.Data;
using Smart.Models;
using Smart.Models.InstructorViewModels;

namespace Smart.Pages.Instructors.Grading
{
    public class IndexModel : PageModel
    {
        private readonly Smart.Data.ApplicationDbContext _context;
        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int clsId { get; set; }
        [BindProperty]
        public bool AssessmentSelected { get; set; }
        [BindProperty]
        public string AssessmentName { get; set; }
        [BindProperty]
        public GradingIndexData GradingData { get; set; }
        [BindProperty]
        public List<SelectListItem> Classes { get; set; }
        [BindProperty]
        public List<SelectListItem> Assessments { get; set; }
        [BindProperty]
        public int AssessmentId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? classId, int? selectedAssessId)
        {
            GradingData = new GradingIndexData();
            GradingData.Classes = await _context.Class.ToListAsync();
            GradingData.StudentAssessments = await _context.StudentAssessment.ToListAsync();
            GradingData.Assessments = await _context.Assessment.ToListAsync();
            GradingData.Students = await _context.StudentClass.ToListAsync();

            AssessmentSelected = false;

            if (classId != null)
            {
                Classes = await _context.Class.Where(c => c.Assessments.Count > 0)
                    .Include(c => c.Term)
                    .Select(c =>
                                new SelectListItem
                                {
                                    Value = c.ClassId.ToString(),
                                    Text = c.Course.Name + " " + c.Term.StartDate.ToString("MMMM") + " to " + c.Term.EndDate.ToString("MMMM") + " " + c.Term.EndDate.Year
                                }).ToListAsync();

                var selectedClass = Classes.Where(c => Convert.ToInt32(c.Value) == classId).FirstOrDefault();
                selectedClass.Selected = true;
            }
            else
            {
                Classes = await _context.Class.Where(c => c.Assessments.Count > 0)
                    .Include(c => c.Term)
                    .Select(c =>
                                new SelectListItem
                                {
                                    Value = c.ClassId.ToString(),
                                    Text = c.Course.Name + " " + c.Term.StartDate.ToString("MMMM") + " to " + c.Term.EndDate.ToString("MMMM") + " " + c.Term.EndDate.Year
                                }).ToListAsync();
            }

            if (classId != null)
            {
                clsId = classId.Value;
                try
                {
                    //var selClass = _context.Class.Include(c => c.Course).Include(c => c.Term).Where(c => c.ClassId == clsId).FirstOrDefault();
                    //Title = selClass.Course.Name + " " + selClass.Term.StartDate.ToString("MMMM") + " to " + selClass.Term.EndDate.ToString("MMMM") + " " + selClass.Term.EndDate.Year;
                    Assessments = await _context.Assessment.Where(a => a.ClassId == clsId).Select(a =>
                                new SelectListItem
                                {
                                    Value = a.AssessmentId.ToString(),
                                    Text = a.Title.ToString()
                                }).ToListAsync();
                    GradingData.Assessments = GradingData.Assessments.Where(a => a.ClassId == clsId).ToList();
                }
                catch
                {

                }
            }

            if (selectedAssessId != null)
            {
                AssessmentId = selectedAssessId.Value;
                AssessmentSelected = true;
                try
                {               
                    Assessment assessment = GradingData.Assessments.Where(a => a.AssessmentId == AssessmentId).Single();
                    AssessmentName = assessment.Title;
                    GradingData.Students = _context.StudentClass.Include(s => s.Student)
                        .Where(s => s.ClassId == assessment.ClassId).ToList();
                    GradingData.StudentAssessments = assessment.StudentAssessments.ToList();                 
                }
                catch
                {
                    GradingData.StudentAssessments = new List<StudentAssessment>();
                }
            }

            return Page();
        }


        public JsonResult OnPost(int? AssessId)
        {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        dynamic dyn = JsonConvert.DeserializeObject(requestBody);
                        var lststudass = new List<StudentAssessment>();
                    try
                    {
                        foreach (var obj in dyn)
                        {
                            lststudass.Add(new StudentAssessment()
                            {
                                StudentId = obj.StudentId,
                                PointsAwarded = obj.PointsAwarded,
                                Comments = obj.Comments,
                                AssessmentId = AssessId.Value
                            }
                            ); ;
                        }
                    }
                    catch
                    {
                        return new JsonResult("Points must be a number");
                    }

                    var assess = _context.Assessment.Where(a => a.AssessmentId == AssessId).Single();

                    foreach (StudentAssessment student in lststudass)
                    {
                        if (student.PointsAwarded > assess.PointsPossible)
                        {
                            return new JsonResult("More points than points possible for the assessment has been given.");
                        }
                    }

                    _context.StudentAssessment.RemoveRange(_context.StudentAssessment.Where(s => s.AssessmentId == AssessId));
                    _context.SaveChanges();

                        foreach(StudentAssessment student in lststudass)
                        {
                            _context.StudentAssessment.Add(student);
                        }
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch
                        {
                            return new JsonResult("An Error Has Occured");
                        }
                    }
                }
            return new JsonResult("Saved Changes Successfully");
        }

    }
}
