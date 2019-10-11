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
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Assessment> Assessment { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<NoteType> NoteType { get; set; }
    }
}
