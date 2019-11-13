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
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
        private readonly Smart.Data.ApplicationDbContext _context;
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    services.AddAntiforgery(o => o.HeaderName = "RequestVerificationToken");
        //}
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
        public async Task<IActionResult> OnGetAsync(int? classId, List<StudentAssessment> studentAssessments)
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
                    Assessment assessment = GradingData.Assessments.Where(a => a.ClassId == classId).Single();
                    GradingData.StudentAssessments = assessment.StudentAssessments.ToList();
                }
                catch
                {
                    clsId = 0;
                }

            }

            return Page();
        }


        public JsonResult OnPost(List<StudentAssessment> assessments)
        {
            //List<StudentAssessment> sa = new List<StudentAssessment>();
            //foreach(StudentAssessment studentAssessment in studentAssessments)
            //{
            //sa.Add(studentAssessment);
            //}
            int sPostValue1;
            double sPostValue2;
            string sPostValue3 = "";
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
                        //if (obj != null)
                        //{
                        //    sPostValue1 = obj.StudentId;
                        //    //sPostValue2 = obj.PointsAwarded;
                        //    //sPostValue3 = obj.Comments;
                        //}
                    }
                }
            }
            return new JsonResult("test");
                return new JsonResult("test: test");
            //do something with the person class
        }

        public class StudentAssessmentTemp
        {

            //public int AssessmentId { get; set; }
            //public virtual Assessment Assessment { get; set; }

            public int StudentId { get; set; }
            //public virtual Student Student { get; set; }
            public double PointsAwarded { get; set; }
            public string Comments { get; set; }
        }

        //public ActionResult OnPostSend()
        //{
        //    List<string> lstString = new List<string>
        //    {
        //        "test",
        //        "test2",
        //        "test3"
        //    };
        //    return new JsonResult(lstString);
        //    //using (CustomersEntities entities = new CustomersEntities())
        //    //{
        //    //    //Truncate Table to delete all old records.
        //    //    entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");

        //    //    //Check for NULL.
        //    //    if (customers == null)
        //    //    {
        //    //        customers = new List<Customer>();
        //    //    }

        //    //    //Loop and insert records.
        //    //    foreach (Customer customer in customers)
        //    //    {
        //    //        entities.Customers.Add(customer);
        //    //    }
        //    //    int insertedRecords = entities.SaveChanges();
        //    //    return Json(insertedRecords);
        //    //}
        //}
    }
}
