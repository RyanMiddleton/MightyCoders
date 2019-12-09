using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart.Data;
using Smart.Models;

namespace Smart.Pages.Application
{
    public class RatingModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public RatingModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicantRating ApplicantRating { get; set; }
        public IList<RatingCriteria> RatingCirterium { get; set; }
        public Student Student { get; set; }

        [BindProperty]
        public List<int> InputValues { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        [BindProperty]
        public int TermId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Student = await _context.Student.FirstOrDefaultAsync(a => a.StudentId == id);

            if (Student == null) return NotFound();

            RatingCirterium = await _context.RatingCriteria.ToListAsync();    //grabbed here to be used in .cshtml

            List<SelectListItem> terms = new List<SelectListItem>();

            var termList = await _context.Term.ToListAsync();

            foreach (var item in termList)
            {
                terms.Add(new SelectListItem { Text = item.StartDate.Date.Year + " (" + item.StartDate.Date.ToShortDateString() + " - " + item.EndDate.ToShortDateString() + ")", Value = item.TermId.ToString() });
            }

            ViewData["terms"] = terms;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            var userIdString = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //int userId = 0; //sets default in case there is an issue getting the id in string form

            //if (!String.IsNullOrEmpty(userIdString))
            //{
            //    userId = int.Parse(userIdString);
            //}

            RatingCirterium = await _context.RatingCriteria.ToListAsync();

            for (var i = 0; i < RatingCirterium.Count; i++)
            {
                var applicantRating = new ApplicantRating
                {
                    StudentId = (int)id,
                    UserId = userIdString,
                    RatingCriteriaId = RatingCirterium[i].RatingCriteriaId,
                    TermId = TermId,
                    ScoreAssigned = InputValues[i],
                    DateTime = DateTime.Now,
                    Comment = Comment
                };

                _context.ApplicantRating.Add(applicantRating);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}