﻿using Microsoft.AspNetCore.Identity;
using Smart.Models;
using Smart.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Data
{
    public class DataSeed
    {
        public static void Initialize(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }

            // Seeding Roles Start
            if (!roleManager.RoleExistsAsync(SD.AdminUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.AdminUser
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync(SD.InstructorUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.InstructorUser
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync(SD.RaterUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.RaterUser
                };
                roleManager.CreateAsync(role).Wait();
            }
            if (!roleManager.RoleExistsAsync(SD.SocialWorkerUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.SocialWorkerUser
                };
                roleManager.CreateAsync(role).Wait();
            }
            // Seeding Roles End

            // Seeding User Start
            if (userManager.FindByEmailAsync("admin@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Morgan",
                    LastName = "Freeman",
                    UserName = "admin@mail.com",
                    Email = "admin@mail.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.AdminUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("instructor1@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "George",
                    LastName = "Feeny",
                    UserName = "instructor1@mail.com",
                    Email = "instructor1@mail.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.InstructorUser).Wait();
                    userManager.AddToRoleAsync(user, SD.RaterUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("instructor2@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Walter",
                    LastName = "White",
                    UserName = "instructor2@mail.com",
                    Email = "instructor2@mail.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.InstructorUser).Wait();
                    userManager.AddToRoleAsync(user, SD.RaterUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("socialworker@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    FirstName = "Kenneth",
                    LastName = "Parcell",
                    UserName = "socialworker@mail.com",
                    Email = "socialworker@mail.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.SocialWorkerUser).Wait();
                }
            }
            // Seeding User End

            // Seeding StudentStatus Start
            var studentStatuses = new StudentStatus[]
            {
                new StudentStatus { Description = "Applicant" },
                new StudentStatus { Description = "Student" },
                new StudentStatus { Description = "Graduate" },
                new StudentStatus { Description = "Withdrew" },
                new StudentStatus { Description = "Accepted" },
                new StudentStatus { Description = "Denied" },
                new StudentStatus { Description = "Waitlisted" }
            };

            foreach (StudentStatus s in studentStatuses)
            {
                context.StudentStatus.Add(s);
            }
            context.SaveChanges();
            // Seeding StudentStatus End

            // Seeding Student Start
            var students = new Student[]
           {
                new Student { FirstName = "Abelina", LastName = "Abreu", DOB = DateTime.Parse("1999-01-01"), Address = "Aye Place 01", Village = "Aye Village",
                    GpsLatitude = 0.0, GpsLongitude = 0.01, PublicSchoolLevel = 4, GuardianName = "Elim", GuardianType = "Father", Phone = "160-532-3452",
                    Photo = null, StudentStatusId = studentStatuses[0].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },

                // Active Students
                new Student { FirstName = "Abiba", LastName = "Arroz", DOB = DateTime.Parse("2000-01-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Abasi", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },
                new Student { FirstName = "Dalila", LastName = "Bata", DOB = DateTime.Parse("2000-11-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Chene", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "Hasina", LastName = "Doane", DOB = DateTime.Parse("2000-03-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Elewa", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "Bahati", LastName = "Fumo", DOB = DateTime.Parse("2000-04-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Abasi", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },
                new Student { FirstName = "Fanaka", LastName = "Bata", DOB = DateTime.Parse("2000-05-12"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Abdu", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "Adia", LastName = "Hele", DOB = DateTime.Parse("2000-06-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Elea", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },

                new Student { FirstName = "Chamila", LastName = "Faife", DOB = DateTime.Parse("2001-01-03"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[2].StudentStatusId, EnglishLevel = 3, ITLevel = 3 },
                new Student { FirstName = "Clesia", LastName = "Camal", DOB = DateTime.Parse("2001-01-04"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[3].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },
                new Student { FirstName = "Elina", LastName = "Machel", DOB = DateTime.Parse("2001-01-05"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[4].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "Eowyn", LastName = "Tamele", DOB = DateTime.Parse("2001-01-06"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[5].StudentStatusId, EnglishLevel = 3, ITLevel = 3 },
                new Student { FirstName = "Genifa", LastName = "Campos", DOB = DateTime.Parse("2001-01-07"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[6].StudentStatusId, EnglishLevel = 1, ITLevel = 1 }
           };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();
            // Seeding Student End

            // Seeding FileType Start
            var fileTypes = new FileType[]
            {
                new FileType { Description = "Application"}
            };

            foreach (FileType s in fileTypes)
            {
                context.FileType.Add(s);
            }
            context.SaveChanges();
            // Seeding FileType End

            // Seeding File Start
            var files = new File[]
            {
                new File { StudentId = students[0].StudentId, Path = "PathToFile1", FileTypeId = fileTypes[0].FileTypeId },
                new File { StudentId = students[1].StudentId, Path = "PathToFile2", FileTypeId = fileTypes[0].FileTypeId },
                new File { StudentId = students[2].StudentId, Path = "PathToFile3", FileTypeId = fileTypes[0].FileTypeId },
            };

            foreach (File s in files)
            {
                context.File.Add(s);
            }
            context.SaveChanges();
            // Seeding File End

            // Seeding NoteType Start
            var noteTypes = new NoteType[]
            {
                new NoteType { Description = "ApplicationProcess" },
                new NoteType { Description = "InstructorNote" },
                new NoteType { Description = "SocialWorkerNote" },
                new NoteType { Description = "Rating" }
            };

            foreach (NoteType s in noteTypes)
            {
                context.NoteType.Add(s);
            }
            context.SaveChanges();
            // Seeding NoteType End

            // Seeding Note Start
            var notes = new Note[]
            {
                new Note { StudentId = students[0].StudentId, UserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id, NoteTypeId = noteTypes[0].NoteTypeId, Text = "Note on Applicaition" },
                new Note { StudentId = students[1].StudentId, UserId = context.ApplicationUser.Single(i => i.LastName == "White").Id, NoteTypeId = noteTypes[1].NoteTypeId, Text = "Note from Instructor" },
                new Note { StudentId = students[2].StudentId, UserId = context.ApplicationUser.Single(i => i.LastName == "Freeman").Id, NoteTypeId = noteTypes[2].NoteTypeId, Text = "Note from Social Worker" },
                new Note { StudentId = students[3].StudentId, UserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id, NoteTypeId = noteTypes[3].NoteTypeId, Text = "Note about rating of applicant" }
            };

            foreach (Note s in notes)
            {
                context.Note.Add(s);
            }
            context.SaveChanges();
            // Seeding Note End

            // Seeding Term Start
            var terms = new Term[]
            {
                new Term { StartDate = DateTime.Parse("2019-08-01"), EndDate = DateTime.Parse("2019-12-13"), TimeOfYear = 2},
                new Term { StartDate = DateTime.Parse("2020-02-01"), EndDate = DateTime.Parse("2020-06-30"), TimeOfYear = 1},
                new Term { StartDate = DateTime.Parse("2020-08-01"), EndDate = DateTime.Parse("2020-11-30"), TimeOfYear = 2},
                new Term { StartDate = DateTime.Parse("2021-02-01"), EndDate = DateTime.Parse("2021-06-30"), TimeOfYear = 1},
                new Term { StartDate = DateTime.Parse("2021-08-01"), EndDate = DateTime.Parse("2021-11-30"), TimeOfYear = 2}
            };

            foreach (Term s in terms)
            {
                context.Term.Add(s);
            }
            context.SaveChanges();
            // Seeding Term End

            // Seeding RatingCriteria Start
            var ratingCriterias = new RatingCriteria[]
            {
                new RatingCriteria { Title = "Finances", Description = "Zero would be very wealthy and the highest value would be extremeley poor.", MaxScore = 30},
                new RatingCriteria { Title = "Academics", Description = "What are their grades, attendance, and academic level in public school?", MaxScore = 30},
                new RatingCriteria { Title = "Family Support and Interest", Description = "How motivated is the student to succeed and complete tasks and does their family support them in their efforts?", MaxScore = 15},
                new RatingCriteria { Title = "Age", Description = "How old is the person compared to other applicants?", MaxScore = 10},
                new RatingCriteria { Title = "Distance", Description = "How far will the student need to travel to school?", MaxScore = 15},
            };

            foreach (RatingCriteria s in ratingCriterias)
            {
                context.RatingCriteria.Add(s);
            }
            context.SaveChanges();
            // Seeding RatingCriteria End

            // Seeding ApplicantRating Start
            var applicantRatings = new ApplicantRating[]
            {
                new ApplicantRating { StudentId = students[0].StudentId, RatingCriteriaId = ratingCriterias[1].RatingCriteriaId, TermId = terms[0].TermId, ScoreAssigned = 48, DateTime = DateTime.Parse("2019-10-30"), Comment = "Great student", UserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new ApplicantRating { StudentId = students[1].StudentId, RatingCriteriaId = ratingCriterias[0].RatingCriteriaId, TermId = terms[1].TermId, ScoreAssigned = 47, DateTime = DateTime.Parse("2019-10-29"), Comment = "Low income student with great potential", UserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new ApplicantRating { StudentId = students[2].StudentId, RatingCriteriaId = ratingCriterias[2].RatingCriteriaId, TermId = terms[2].TermId, ScoreAssigned = 49, DateTime = DateTime.Parse("2019-10-28"), Comment = "Hard working student", UserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new ApplicantRating { StudentId = students[3].StudentId, RatingCriteriaId = ratingCriterias[1].RatingCriteriaId, TermId = terms[3].TermId, ScoreAssigned = 49, DateTime = DateTime.Parse("2019-10-28"), Comment = "Perfect grades in public school", UserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id }
            };

            foreach (ApplicantRating s in applicantRatings)
            {
                context.ApplicantRating.Add(s);
            }
            context.SaveChanges();
            // Seeding ApplicantRating End

            // Seeding Course Start
            var courses = new Course[]
            {
                new Course { Name = "ENG1", IsCoreRequirement = true, IsTaughtHere = true },
                new Course { Name = "ENG2", IsCoreRequirement = true, IsTaughtHere = true },
                new Course { Name = "ENG3", IsCoreRequirement = false, IsTaughtHere = true },
                new Course { Name = "IT1", IsCoreRequirement = true, IsTaughtHere = true },
                new Course { Name = "IT2", IsCoreRequirement = false, IsTaughtHere = true },
                new Course { Name = "IT3", IsCoreRequirement = false, IsTaughtHere = true },
                new Course { Name = "Gym", IsCoreRequirement = false, IsTaughtHere = false },
                new Course { Name = "Math", IsCoreRequirement = false, IsTaughtHere = false },
                new Course { Name = "Cooking", IsCoreRequirement = false, IsTaughtHere = false }
            };

            foreach (Course s in courses)
            {
                context.Course.Add(s);
            }
            context.SaveChanges();
            // Seeding Course End

            // Seeding Class Start
            var classes = new Class[]
            {
                new Class { CourseId = courses[0].CourseId, TermId = terms[0].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[1].CourseId, TermId = terms[0].TermId, Capacity = 20, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[2].CourseId, TermId = terms[0].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[3].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[4].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[5].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },

                new Class { CourseId = courses[1].CourseId, TermId = terms[1].TermId, Capacity = 20, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[2].CourseId, TermId = terms[1].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[3].CourseId, TermId = terms[1].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[4].CourseId, TermId = terms[1].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[5].CourseId, TermId = terms[1].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },

                new Class { CourseId = courses[0].CourseId, TermId = terms[2].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[1].CourseId, TermId = terms[2].TermId, Capacity = 20, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[2].CourseId, TermId = terms[2].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[4].CourseId, TermId = terms[2].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[5].CourseId, TermId = terms[2].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },

                new Class { CourseId = courses[1].CourseId, TermId = terms[3].TermId, Capacity = 20, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[2].CourseId, TermId = terms[3].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[4].CourseId, TermId = terms[3].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[5].CourseId, TermId = terms[3].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },

                // public school classes index 21 - 32
                new Class { CourseId = courses[6].CourseId, TermId = terms[0].TermId },
                new Class { CourseId = courses[6].CourseId, TermId = terms[1].TermId },
                new Class { CourseId = courses[6].CourseId, TermId = terms[2].TermId },
                new Class { CourseId = courses[6].CourseId, TermId = terms[3].TermId },
                new Class { CourseId = courses[7].CourseId, TermId = terms[0].TermId },
                new Class { CourseId = courses[7].CourseId, TermId = terms[1].TermId },
                new Class { CourseId = courses[7].CourseId, TermId = terms[2].TermId },
                new Class { CourseId = courses[7].CourseId, TermId = terms[3].TermId },
                new Class { CourseId = courses[8].CourseId, TermId = terms[0].TermId },
                new Class { CourseId = courses[8].CourseId, TermId = terms[1].TermId },
                new Class { CourseId = courses[8].CourseId, TermId = terms[2].TermId },
                new Class { CourseId = courses[8].CourseId, TermId = terms[3].TermId }
            };

            foreach (Class s in classes)
            {
                context.Class.Add(s);
            }
            context.SaveChanges();
            // Seeding Class End

            // Seeding Assessment Start
            var assessments = new Assessment[]
            {
                new Assessment { ClassId = classes[0].ClassId, Title = "Exam1", Description = "Begginer english test" , PointsPossible = 100 },
                new Assessment { ClassId = classes[1].ClassId, Title = "Exam2", Description = "Medium difficulty english test" , PointsPossible = 100 },
                new Assessment { ClassId = classes[2].ClassId, Title = "Exam3", Description = "Hard english test" , PointsPossible = 100 },
                new Assessment { ClassId = classes[3].ClassId, Title = "Exam1", Description = "Type 30 words per minute" , PointsPossible = 100 },
            };

            foreach (Assessment s in assessments)
            {
                context.Assessment.Add(s);
            }
            context.SaveChanges();
            // Seeding Assessment End

            // Seeding StudentAssessment Start
            var studentAssessments = new StudentAssessment[]
            {
                new StudentAssessment { StudentId = students[0].StudentId, AssessmentId = assessments[0].AssessmentId, PointsAwarded = 100, SubmissionDateTime = DateTime.Now },
                new StudentAssessment { StudentId = students[1].StudentId, AssessmentId = assessments[1].AssessmentId, PointsAwarded = 100, SubmissionDateTime = DateTime.Now },
                new StudentAssessment { StudentId = students[2].StudentId, AssessmentId = assessments[2].AssessmentId, PointsAwarded = 100, SubmissionDateTime = DateTime.Now },
                new StudentAssessment { StudentId = students[3].StudentId, AssessmentId = assessments[3].AssessmentId, PointsAwarded = 100, SubmissionDateTime = DateTime.Now }
            };

            foreach (StudentAssessment s in studentAssessments)
            {
                context.StudentAssessment.Add(s);
            }
            context.SaveChanges();
            // Seeding StudentAssessment End

            // Seeding AttendanceStatus Start
            var attendanceStatuses = new AttendanceStatus[]
            {
                new AttendanceStatus { Description = "On Time"},
                new AttendanceStatus { Description = "Late"},
                new AttendanceStatus { Description = "Absent"}
            };

            foreach (AttendanceStatus s in attendanceStatuses)
            {
                context.AttendanceStatus.Add(s);
            }
            context.SaveChanges();
            // Seeding AttendanceStatus End

            // Seeding Attendance Start
            var attendances = new Attendance[]
            {
                new Attendance { StudentId = students[0].StudentId, ClassId = classes[0].ClassId, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("12:00:00"), AttendanceStatusId = attendanceStatuses[0].AttendanceStatusId },
                new Attendance { StudentId = students[1].StudentId, ClassId = classes[1].ClassId, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("14:00:00"), AttendanceStatusId = attendanceStatuses[1].AttendanceStatusId },
                new Attendance { StudentId = students[2].StudentId, ClassId = classes[2].ClassId, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("15:00:00"), AttendanceStatusId = attendanceStatuses[2].AttendanceStatusId },
                new Attendance { StudentId = students[3].StudentId, ClassId = classes[3].ClassId, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("16:00:00"), AttendanceStatusId = attendanceStatuses[2].AttendanceStatusId }
            };

            foreach (Attendance s in attendances)
            {
                context.Attendance.Add(s);
            }
            context.SaveChanges();
            // Seeding Attendance End

            // Seeding Schedule Start
            var scheduleAvailabilities = new ScheduleAvailability[]
            {
                // term[0]
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[0].TermId },

                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[0].TermId },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[0].TermId },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[0].TermId },

                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[0].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[0].TermId },

                // term[1]
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[1].TermId },
                //new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[1].TermId },
                //new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[1].TermId },

                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[1].TermId },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[1].TermId },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[1].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[1].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[1].TermId },

                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[1].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[1].TermId },

                // term[2]
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[2].TermId },

                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[2].TermId },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[2].TermId },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[2].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[2].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[2].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[2].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[2].TermId },
                //new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[2].TermId },

                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[2].TermId },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[2].TermId },

                // term[3]
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId }, new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                // term[4]
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId },

                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00"), TermId = terms[3].TermId }, new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00"), TermId = terms[3].TermId },
                //new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00"), TermId = terms[3].TermId }
            };

            foreach (ScheduleAvailability s in scheduleAvailabilities)
            {
                context.ScheduleAvailability.Add(s);
            }
            context.SaveChanges();
            // Seeding Schedule End

            // Seeding Section Start
            var sections = new Section[]
            {
                new Section { Name = "A" },
                new Section { Name = "B" },
                new Section { Name = "C" },
                new Section { Name = "D" }
            };

            foreach (Section s in sections)
            {
                context.Section.Add(s);
            }
            context.SaveChanges();

            // Seeding ClassSchedule Start
            var classSchedules = new ClassSchedule[]
            {
                new ClassSchedule { ClassId = classes[0].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[0].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[1].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[1].ScheduleAvailabilityId, SectionId = sections[1].SectionId },
                new ClassSchedule { ClassId = classes[2].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[2].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[3].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[3].ScheduleAvailabilityId, SectionId = sections[1].SectionId },
                new ClassSchedule { ClassId = classes[4].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[4].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[5].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[5].ScheduleAvailabilityId, SectionId = sections[1].SectionId },

                new ClassSchedule { ClassId = classes[0].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[6].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[1].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[7].ScheduleAvailabilityId, SectionId = sections[1].SectionId },
                new ClassSchedule { ClassId = classes[2].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[8].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[3].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[9].ScheduleAvailabilityId, SectionId = sections[1].SectionId },
                new ClassSchedule { ClassId = classes[4].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[10].ScheduleAvailabilityId, SectionId = sections[0].SectionId },
                new ClassSchedule { ClassId = classes[5].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[11].ScheduleAvailabilityId, SectionId = sections[1].SectionId },

                // Public class shceduels
                new ClassSchedule { ClassId = classes[20].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[16].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[21].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[17].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[22].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[8].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[23].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[4].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[24].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[1].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[25].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[11].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[26].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[13].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[27].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[20].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[28].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[18].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[29].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[22].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[30].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[10].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[31].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[3].ScheduleAvailabilityId },
            };

            foreach (ClassSchedule s in classSchedules)
            {
                context.ClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding ClassSchedule End

            // Seeding StudentClassSchedule Start
            var StudentClassSchedulees = new StudentClassSchedule[]
            {
                // public classes
                new StudentClassSchedule { ClassScheduleId = classSchedules[21].ClassScheduleId, StudentId = students[1].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[22].ClassScheduleId, StudentId = students[2].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[23].ClassScheduleId, StudentId = students[3].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[24].ClassScheduleId, StudentId = students[3].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[25].ClassScheduleId, StudentId = students[2].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[26].ClassScheduleId, StudentId = students[1].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[21].ClassScheduleId, StudentId = students[4].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[22].ClassScheduleId, StudentId = students[5].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[23].ClassScheduleId, StudentId = students[6].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[24].ClassScheduleId, StudentId = students[6].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[25].ClassScheduleId, StudentId = students[5].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[26].ClassScheduleId, StudentId = students[4].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[27].ClassScheduleId, StudentId = students[1].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[28].ClassScheduleId, StudentId = students[2].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[29].ClassScheduleId, StudentId = students[3].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[30].ClassScheduleId, StudentId = students[3].StudentId },
                new StudentClassSchedule { ClassScheduleId = classSchedules[31].ClassScheduleId, StudentId = students[2].StudentId }
            };

            foreach (StudentClassSchedule s in StudentClassSchedulees)
            {
                context.StudentClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding StudentClassSchedule End
        }
    }
} 