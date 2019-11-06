using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }
        //[Required]
        //[Display(Name = "Last Name")]
        public string LastName { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<ApplicantRating> ApplicantRatings { get; set; }
    }
}
