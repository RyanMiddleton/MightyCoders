﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.Data;

namespace Smart.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Smart.Models.ApplicantRating", b =>
                {
                    b.Property<int>("ApplicantRatingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<DateTime>("DateTime");

                    b.Property<int>("RatingCriteriaId");

                    b.Property<int>("ScoreAssigned");

                    b.Property<int>("StudentId");

                    b.Property<int>("TermId");

                    b.Property<string>("UserId");

                    b.HasKey("ApplicantRatingId");

                    b.HasIndex("RatingCriteriaId");

                    b.HasIndex("StudentId");

                    b.HasIndex("TermId");

                    b.HasIndex("UserId");

                    b.ToTable("ApplicantRating");
                });

            modelBuilder.Entity("Smart.Models.Assessment", b =>
                {
                    b.Property<int>("AssessmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<string>("Description");

                    b.Property<int>("PointsPossible");

                    b.Property<string>("Title");

                    b.HasKey("AssessmentId");

                    b.HasIndex("ClassId");

                    b.ToTable("Assessment");
                });

            modelBuilder.Entity("Smart.Models.Attendance", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("AttendanceStatusId");

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("TimeIn");

                    b.HasKey("StudentId");

                    b.HasIndex("AttendanceStatusId");

                    b.HasIndex("ClassId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("Smart.Models.AttendanceStatus", b =>
                {
                    b.Property<int>("AttendanceStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("AttendanceStatusId");

                    b.ToTable("AttendanceStatus");
                });

            modelBuilder.Entity("Smart.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity");

                    b.Property<int>("CourseId");

                    b.Property<string>("InstructorUserId");

                    b.Property<int>("TermId");

                    b.HasKey("ClassId");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorUserId");

                    b.HasIndex("TermId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Smart.Models.ClassSchedule", b =>
                {
                    b.Property<int>("ClassScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<int>("ScheduleAvailabilityId");

                    b.Property<int?>("SectionId");

                    b.HasKey("ClassScheduleId");

                    b.HasIndex("ClassId");

                    b.HasIndex("ScheduleAvailabilityId");

                    b.HasIndex("SectionId");

                    b.ToTable("ClassSchedule");
                });

            modelBuilder.Entity("Smart.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsCoreRequirement");

                    b.Property<bool>("IsTaughtHere");

                    b.Property<string>("Name");

                    b.HasKey("CourseId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Smart.Models.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FileTypeId");

                    b.Property<string>("Path");

                    b.Property<int>("StudentId");

                    b.HasKey("FileId");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("File");
                });

            modelBuilder.Entity("Smart.Models.FileType", b =>
                {
                    b.Property<int>("FileTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("FileTypeId");

                    b.ToTable("FileType");
                });

            modelBuilder.Entity("Smart.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("Disabled");

                    b.Property<int>("NoteTypeId");

                    b.Property<int>("StudentId");

                    b.Property<string>("Text");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("NoteId");

                    b.HasIndex("NoteTypeId");

                    b.HasIndex("StudentId");

                    b.HasIndex("UserId");

                    b.ToTable("Note");
                });

            modelBuilder.Entity("Smart.Models.NoteType", b =>
                {
                    b.Property<int>("NoteTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("NoteTypeId");

                    b.ToTable("NoteType");
                });

            modelBuilder.Entity("Smart.Models.RatingCriteria", b =>
                {
                    b.Property<int>("RatingCriteriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("MaxScore");

                    b.Property<string>("Title");

                    b.HasKey("RatingCriteriaId");

                    b.ToTable("RatingCriteria");
                });

            modelBuilder.Entity("Smart.Models.ScheduleAvailability", b =>
                {
                    b.Property<int>("ScheduleAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfWeek");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("TermId");

                    b.HasKey("ScheduleAvailabilityId");

                    b.HasIndex("TermId");

                    b.ToTable("ScheduleAvailability");
                });

            modelBuilder.Entity("Smart.Models.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("SectionId");

                    b.ToTable("Section");
                });

            modelBuilder.Entity("Smart.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("DOB");

                    b.Property<int>("EnglishLevel");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<double>("GpsLatitude");

                    b.Property<double>("GpsLongitude");

                    b.Property<string>("GuardianName");

                    b.Property<string>("GuardianType");

                    b.Property<int>("ITLevel");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<byte[]>("Photo");

                    b.Property<int>("PublicSchoolLevel");

                    b.Property<int>("StudentStatusId");

                    b.Property<string>("Village");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentStatusId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Smart.Models.StudentAssessment", b =>
                {
                    b.Property<int>("AssessmentId");

                    b.Property<int>("StudentId");

                    b.Property<string>("Comments");

                    b.Property<int?>("FileId");

                    b.Property<double>("PointsAwarded");

                    b.Property<DateTime>("SubmissionDateTime");

                    b.HasKey("AssessmentId", "StudentId");

                    b.HasIndex("FileId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAssessment");
                });

            modelBuilder.Entity("Smart.Models.StudentClass", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("ClassId");

                    b.HasKey("StudentId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("StudentClass");
                });

            modelBuilder.Entity("Smart.Models.StudentClassSchedule", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("ClassScheduleId");

                    b.HasKey("StudentId", "ClassScheduleId");

                    b.HasIndex("ClassScheduleId");

                    b.ToTable("StudentClassSchedule");
                });

            modelBuilder.Entity("Smart.Models.StudentStatus", b =>
                {
                    b.Property<int>("StudentStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("StudentStatusId");

                    b.ToTable("StudentStatus");
                });

            modelBuilder.Entity("Smart.Models.Term", b =>
                {
                    b.Property<int>("TermId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TimeOfYear");

                    b.HasKey("TermId");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("Smart.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.ApplicantRating", b =>
                {
                    b.HasOne("Smart.Models.RatingCriteria", "RatingCriteria")
                        .WithMany()
                        .HasForeignKey("RatingCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("ApplicantRatings")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Term", "Term")
                        .WithMany("ApplicantRatings")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ApplicantRatings")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Smart.Models.Assessment", b =>
                {
                    b.HasOne("Smart.Models.Class", "Class")
                        .WithMany("Assessments")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.Attendance", b =>
                {
                    b.HasOne("Smart.Models.AttendanceStatus", "AttendanceStatus")
                        .WithMany("Attendances")
                        .HasForeignKey("AttendanceStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Class", "Class")
                        .WithMany("Attendances")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.Class", b =>
                {
                    b.HasOne("Smart.Models.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Classes")
                        .HasForeignKey("InstructorUserId");

                    b.HasOne("Smart.Models.Term", "Term")
                        .WithMany("Classes")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.ClassSchedule", b =>
                {
                    b.HasOne("Smart.Models.Class", "Class")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.ScheduleAvailability", "ScheduleAvailability")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("ScheduleAvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Section", "Section")
                        .WithMany("ClassSchedules")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("Smart.Models.File", b =>
                {
                    b.HasOne("Smart.Models.FileType", "FileType")
                        .WithMany("Files")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("Files")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.Note", b =>
                {
                    b.HasOne("Smart.Models.NoteType", "NoteType")
                        .WithMany("Notes")
                        .HasForeignKey("NoteTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("Notes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Notes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.ScheduleAvailability", b =>
                {
                    b.HasOne("Smart.Models.Term", "Term")
                        .WithMany("ScheduleAvailabilities")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.Student", b =>
                {
                    b.HasOne("Smart.Models.StudentStatus", "StudentStatus")
                        .WithMany("Students")
                        .HasForeignKey("StudentStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.StudentAssessment", b =>
                {
                    b.HasOne("Smart.Models.Assessment", "Assessment")
                        .WithMany("StudentAssessments")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.File", "File")
                        .WithMany("StudentAssessments")
                        .HasForeignKey("FileId");

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("StudentAssessments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.StudentClass", b =>
                {
                    b.HasOne("Smart.Models.Class", "Class")
                        .WithMany("StudentClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("StudentClasses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Smart.Models.StudentClassSchedule", b =>
                {
                    b.HasOne("Smart.Models.ClassSchedule", "ClassSchedule")
                        .WithMany("StudentClassSchedules")
                        .HasForeignKey("ClassScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Smart.Models.Student", "Student")
                        .WithMany("StudentClassSchedules")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
