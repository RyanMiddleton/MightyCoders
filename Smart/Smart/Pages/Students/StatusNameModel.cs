using Smart.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Smart.Pages.Students
{
    public class StatusNameModel : PageModel
    {
        public SelectList StatusNameSL { get; set; }

        public void PopulateStatusDropDownList(ApplicationDbContext _context,
            object selectedStatus = null)
        {
            var statusQuery = from s in _context.StudentStatus
                                   orderby s.Description // Sort by name.
                                   select s;

            StatusNameSL = new SelectList(statusQuery.AsNoTracking(),
                        "StudentStatusId", "Description", statusQuery);
        }
    }
}
