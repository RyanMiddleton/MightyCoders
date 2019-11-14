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
        public Assessment assessment { get; set; }
        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int clsId { get; set; }
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
            GradingData.Students = await _context.Student.ToListAsync();

            Classes = await _context.Class.Select(c =>
                                            new SelectListItem
                                            {
                                                Value = c.ClassId.ToString(),
                                                Text = c.Course.Name.ToString()
                                            }).ToListAsync();

            if (classId != null)
            {
                clsId = classId.Value;
                try
                {
                    Assessments = await _context.Assessment.Where(a => a.ClassId == clsId).Select(a =>
                                new SelectListItem
                                {
                                    Value = a.AssessmentId.ToString(),
                                    Text = a.Title.ToString()
                                }).ToListAsync();
                }
                catch
                {
                    clsId = 0;
                }
            }

            if (selectedAssessId != null)
            {
                AssessmentId = selectedAssessId.Value;
                try
                {
                    Assessment assessment = GradingData.Assessments.Where(a => a.AssessmentId == AssessmentId).Single();
                    GradingData.StudentAssessments = assessment.StudentAssessments.ToList();
                    AssessmentId = assessment.AssessmentId;
                }
                catch
                {
                    AssessmentId = 0;
                }
            }

            return Page();
        }


        public JsonResult OnPost(int? AssessId)
        {
            {

                _context.StudentAssessment.RemoveRange(_context.StudentAssessment.Where(s => s.AssessmentId == AssessId));
                _context.SaveChanges();
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
                        foreach(var obj in dyn)
                        {
                            lststudass.Add(new StudentAssessment()
                            {
                                StudentId = obj.StudentId,
                                PointsAwarded = obj.PointsAwarded,
                                Comments = obj.Comments
                            }
                            );
                        }
                    }
                }
            }
            return new JsonResult("test");
        }

    }
}
