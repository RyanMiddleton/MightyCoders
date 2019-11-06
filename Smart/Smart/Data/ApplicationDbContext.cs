using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Smart.Models;

namespace Smart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<ApplicantRating> ApplicantRating { get; set; }
        public DbSet<RatingCriteria> RatingCriteria { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<FileType> FileType { get; set; }
        public DbSet<StudentStatus> StudentStatus { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<NoteType> NoteType { get; set; }
        public DbSet<StudentClass> StudentClass { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatus { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<StudentAssessment> StudentAssessment { get; set; }
        public DbSet<ClassSchedule> ClassSchedule { get; set; }
        public DbSet<ScheduleAvailability> ScheduleAvailability { get; set; }
        public DbSet<PublicSchoolClassSchedule> PublicSchoolClassSchedule { get; set; }
        public DbSet<StudentPublicSchoolClass> StudentPublicSchoolClass { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentClass>()
                .HasKey(c => new { c.StudentId, c.ClassId });
            modelBuilder.Entity<StudentAssessment>()
                .HasKey(c => new { c.AssessmentId, c.StudentId });
            modelBuilder.Entity<ClassSchedule>()
                .HasKey(c => new { c.ClassId, c.ScheduleAvailabilityId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
