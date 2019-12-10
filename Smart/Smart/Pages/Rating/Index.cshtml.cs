using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Rating
{
    public class IndexModel : PageModel
    {
        #region Contructor
        private readonly Smart.Data.ApplicationDbContext _context;

        public IndexModel(Smart.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties
        public List<Student> Student { get; set; }
        public List<ApplicantRating> ApplicantRating { get; set; }
        public int ScorePossible { get; set; }
        public string CurrentUserId { get; set; }
        #endregion

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            //calculate the total possible score for the current criteria (referenced in the .cshtml)
            var rc = await _context.RatingCriteria.ToListAsync();

            foreach (var criteria in rc)
            {
                ScorePossible += criteria.MaxScore;
            }

            //get student list & create instance of RatingCriteria
            IQueryable<Student> studentIQ = _context.Student.Where(a => a.StudentStatus.Description == "Applicant").AsQueryable();//change to where status != active or graduated
            ApplicantRating = await _context.ApplicantRating.ToListAsync();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    studentIQ = studentIQ.Where(a => a.FirstName.Contains(searchString) || a.LastName.Contains(searchString));
            //}

            //studentIQ = sortOrder switch //create sorting options
            //{
            //    "last_name_desc" => studentIQ.OrderByDescending(s => s.LastName),
            //    "first_name_desc" => studentIQ.OrderByDescending(s => s.FirstName),
            //    "FirstName" => studentIQ.OrderBy(s => s.FirstName),
            //    "public_school_level_desc" => studentIQ.OrderByDescending(s => s.PublicSchoolLevel),
            //    "PublicSchoolLevel" => studentIQ.OrderBy(s => s.PublicSchoolLevel),
            //    "status_desc" => studentIQ.OrderByDescending(s => s.StudentStatus),
            //    "Status" => studentIQ.OrderBy(s => s.StudentStatus),
            //    "score_desc" => studentIQ.OrderBy(a => a.ApplicantRatings.Sum(s => s.ScoreAssigned)),
            //    "Score" => studentIQ.OrderByDescending(a => a.ApplicantRatings.Sum(s => s.ScoreAssigned)),
            //    _ => studentIQ.OrderBy(s => s.LastName),
            //};

            Student = await studentIQ.AsNoTracking().ToListAsync();

            SetCurrentUserId();

        }

        public void SetCurrentUserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            /* int userId = 0;*/ //sets default in case there is an issue getting the id in string form
                                 //if (!String.IsNullOrEmpty(userIdString))
                                 //{
                                 //    userId = int.Parse(userIdString);
                                 //}

            CurrentUserId = userId;
        }

        public bool SetShowCheckBox(int studentId)
        {
            var test = _context.ApplicantRating.Where(a => a.UserId == CurrentUserId && a.StudentId == studentId).ToList();

            //if the query brings any results at all
            if ((test != null) && (test.Any()))
            {
                //IsChecked = true;
                return true;
            }
            else
            {
                //IsChecked = false;
                return false;
            }
        }
    }
}