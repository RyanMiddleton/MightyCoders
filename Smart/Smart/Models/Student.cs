using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Student
    {
        //[Key]
        public int StudentId { get; set; }
        //[Required]
        //[Display(Name = "First Name")]
        public string FirstName { get; set; }
        //[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //[Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        public double GpsLongitude { get; set; } 
        public double GpsLatitude { get; set; }
        public int PublicSchoolLevel { get; set; }
        //[Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }
        //[Display(Name = "Guardian Type")]
        public string GuardianType { get; set; }
        //[Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        //[Required]
        public int StudentStatusId { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<ApplicantRating> ApplicantRatings { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}
