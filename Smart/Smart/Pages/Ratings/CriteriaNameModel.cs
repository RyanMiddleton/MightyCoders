using Smart.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Smart.Pages.Ratings
{
    public class CriteriaNameModel : PageModel
    {
        public SelectList CriteriaNameSL { get; set; }
        public SelectList TermNameSL { get; set; }
        public void PopulateCriteriaDropDownList(ApplicationDbContext _context,
            object selectedCriteria = null)
        {
            var statusQuery = from s in _context.RatingCriteria
                              orderby s.Description // Sort by name.
                              select s;

            CriteriaNameSL = new SelectList(statusQuery.AsNoTracking(),
                        "RatingCriteriaId", "Description", statusQuery);
        }

        public void PopulateTermDropDownList(ApplicationDbContext _context,
           object selectedTerm = null)
        {
            var statusQuery = from s in _context.Term
                              orderby s.StartDate // Sort by start date.
                              select s;

            TermNameSL = new SelectList(statusQuery.AsNoTracking(),
                        "TermId", "Description", statusQuery);
        }

    }
}
