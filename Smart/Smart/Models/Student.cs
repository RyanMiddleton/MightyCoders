﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Student Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Village { get; set; }
        [Display(Name ="Longitude")]
        public double GpsLongitude { get; set; } 
        [Display(Name = "Latitude")]
        public double GpsLatitude { get; set; }
        [Display(Name = "Public School Level")]
        public int PublicSchoolLevel { get; set; }
        [Display(Name = "English Level")]
        public int EnglishLevel { get; set; }
        [Display(Name = "IT Level")]
        public int ITLevel { get; set; }
        [Display(Name = "Guardian Name")]
        public string GuardianName { get; set; }
        [Display(Name = "Guardian Type")]
        public string GuardianType { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        [Display(Name = "Student Status")]
        public int StudentStatusId { get; set; }
        public StudentStatus StudentStatus { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<ApplicantRating> ApplicantRatings { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<StudentClassSchedule> StudentClassSchedules { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
        public virtual ICollection<StudentAssessment> StudentAssessments { get; set; }
    }
}
