using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }
        [Display(Name = "Guardian Type")]
        public string GuardianType { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public string Status { get; set; }
        public enum EStatus { Applicant, Student, Withdrawn, Graduate }
        public int PublicSchoolLevel { get; set; } // not sure how they do their grades yet
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public double Longitude { get; set; } // I'll look into a good way to store gps location
        public double Latitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string Village { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }

    }
}
