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
            IQueryable<Student> studentIQ = _context.Student
                .OrderBy(a=> a.LastName)
                .Where(a => a.StudentStatus.Description == "Applicant")
                .AsQueryable();
            ApplicantRating = await _context.ApplicantRating.ToListAsync();
            Student = await studentIQ.AsNoTracking().ToListAsync();

            SetCurrentUserId();

        }

        public void SetCurrentUserId()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

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