using Microsoft.AspNetCore.Identity;
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

            /*// Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }*/

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
                new Student { FirstName = "Jame", LastName = "Smith", DOB = DateTime.Parse("1999-01-01"), Address = "Aye Place 01", Village = "Aye Village",
                    GpsLatitude = 0.0, GpsLongitude = 0.01, PublicSchoolLevel = 4, GuardianName = "James", GuardianType = "Father", Phone = "160-532-3452",
                    Photo = null, StudentStatusId = studentStatuses[0].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },
                new Student { FirstName = "David", LastName = "Johnson", DOB = DateTime.Parse("2000-01-02"), Address = "Aye Place 02", Village = "Aye Village",
                    GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Hela", GuardianType = "Father", Phone = "423-542-4231",
                    Photo = null, StudentStatusId = studentStatuses[1].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "Christopher", LastName = "Williams", DOB = DateTime.Parse("2001-01-03"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[2].StudentStatusId, EnglishLevel = 3, ITLevel = 3 },
                new Student { FirstName = "George", LastName = "Jones", DOB = DateTime.Parse("2001-01-04"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[3].StudentStatusId, EnglishLevel = 1, ITLevel = 1 },
                new Student { FirstName = "Ronald", LastName = "Brown", DOB = DateTime.Parse("2001-01-05"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[4].StudentStatusId, EnglishLevel = 2, ITLevel = 2 },
                new Student { FirstName = "John", LastName = "Davis", DOB = DateTime.Parse("2001-01-06"), Address = "Aye Place 03", Village = "Aynotha Village",
                    GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663",
                    Photo = null, StudentStatusId = studentStatuses[5].StudentStatusId, EnglishLevel = 3, ITLevel = 3 },
                new Student { FirstName = "Corey", LastName = "Wilson", DOB = DateTime.Parse("2001-01-07"), Address = "Aye Place 03", Village = "Aynotha Village",
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
                new Term { Description = "Spring2020", StartDate = DateTime.Parse("2020-02-01"), EndDate = DateTime.Parse("2020-06-30"), TimeOfYear = 1},
                new Term { Description = "Fall2020", StartDate = DateTime.Parse("2020-08-01"), EndDate = DateTime.Parse("2020-11-30"), TimeOfYear = 2},
                new Term { Description = "Spring2021", StartDate = DateTime.Parse("2021-02-01"), EndDate = DateTime.Parse("2021-06-30"), TimeOfYear = 1},
                new Term { Description = "Fall2021", StartDate = DateTime.Parse("2021-08-01"), EndDate = DateTime.Parse("2021-11-30"), TimeOfYear = 2}
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
                new RatingCriteria { Description = "Income", MaxScore = 50},
                new RatingCriteria { Description = "Education", MaxScore = 50},
                new RatingCriteria { Description = "Motivation", MaxScore = 50}
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
                new Course { Name = "ENG1"},
                new Course { Name = "ENG2"},
                new Course { Name = "ENG3"},
                new Course { Name = "IT1"},
                new Course { Name = "IT2"},
                new Course { Name = "IT3"}
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
                new Class { CourseId = courses[1].CourseId, TermId = terms[1].TermId, Capacity = 20, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[2].CourseId, TermId = terms[2].TermId, Capacity = 15, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "Feeny").Id },
                new Class { CourseId = courses[3].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[4].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id },
                new Class { CourseId = courses[5].CourseId, TermId = terms[0].TermId, Capacity = 25, InstructorUserId = context.ApplicationUser.Single(i => i.LastName == "White").Id }
            };

            foreach (Class s in classes)
            {
                context.Class.Add(s);
            }
            context.SaveChanges();
            // Seeding Class End

            // Seeding StudentClass Start
            var studentClasses = new StudentClass[]
            {
                new StudentClass { ClassId = classes[0].ClassId, StudentId = students[0].StudentId },
                new StudentClass { ClassId = classes[1].ClassId, StudentId = students[1].StudentId },
                new StudentClass { ClassId = classes[2].ClassId, StudentId = students[2].StudentId },
                new StudentClass { ClassId = classes[3].ClassId, StudentId = students[3].StudentId }
            };

            foreach (StudentClass s in studentClasses)
            {
                context.StudentClass.Add(s);
            }
            context.SaveChanges();
            // Seeding StudentClass End

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
                new StudentAssessment { StudentId = students[0].StudentId, AssessmentId = assessments[0].AssessmentId, PointsAwarded = 100},
                new StudentAssessment { StudentId = students[1].StudentId, AssessmentId = assessments[1].AssessmentId, PointsAwarded = 100},
                new StudentAssessment { StudentId = students[2].StudentId, AssessmentId = assessments[2].AssessmentId, PointsAwarded = 100},
                new StudentAssessment { StudentId = students[3].StudentId, AssessmentId = assessments[3].AssessmentId, PointsAwarded = 100}
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
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00") },
                new ScheduleAvailability { DayOfWeek = 1, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00") },

                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00") },
                new ScheduleAvailability { DayOfWeek = 2, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00") },

                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00") },
                new ScheduleAvailability { DayOfWeek = 3, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00") },

                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00") },
                new ScheduleAvailability { DayOfWeek = 4, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00") },

                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("08:00:00"), EndTime = DateTime.Parse("09:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("09:00:00"), EndTime = DateTime.Parse("10:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("10:00:00"), EndTime = DateTime.Parse("11:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00") },
                new ScheduleAvailability { DayOfWeek = 5, StartTime = DateTime.Parse("14:00:00"), EndTime = DateTime.Parse("15:00:00") }
            };

            foreach (ScheduleAvailability s in scheduleAvailabilities)
            {
                context.ScheduleAvailability.Add(s);
            }
            context.SaveChanges();
            // Seeding Schedule End

            // Seeding ClassSchedule Start
            var classSchedules = new ClassSchedule[]
            {
                new ClassSchedule { ClassId = classes[0].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[0].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[1].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[1].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[2].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[2].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[3].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[3].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[4].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[4].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[5].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[5].ScheduleAvailabilityId },

                new ClassSchedule { ClassId = classes[0].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[6].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[1].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[7].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[2].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[8].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[3].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[9].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[4].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[10].ScheduleAvailabilityId },
                new ClassSchedule { ClassId = classes[5].ClassId, ScheduleAvailabilityId = scheduleAvailabilities[11].ScheduleAvailabilityId },
            };

            foreach (ClassSchedule s in classSchedules)
            {
                context.ClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding ClassSchedule End

            // Seeding studentPublicSchoolClasses Start
            var studentPublicSchoolClasses = new StudentPublicSchoolClass[]
            {
                new StudentPublicSchoolClass { StudentId = students[0].StudentId, CourseName = "Gym" },
                new StudentPublicSchoolClass { StudentId = students[1].StudentId, CourseName = "Math" },
                new StudentPublicSchoolClass { StudentId = students[2].StudentId, CourseName = "Cooking" }
            };

            foreach (StudentPublicSchoolClass s in studentPublicSchoolClasses)
            {
                context.StudentPublicSchoolClass.Add(s);
            }
            context.SaveChanges();
            // Seeding studentPublicSchoolClasses End

            // Seeding publicSchoolClassSchedules Start
            var publicSchoolClassSchedules = new PublicSchoolClassSchedule[]
            {
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = studentPublicSchoolClasses[0].StudentPublicSchoolClassId, ScheduleAvailabilityId = scheduleAvailabilities[12].ScheduleAvailabilityId },
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = studentPublicSchoolClasses[1].StudentPublicSchoolClassId, ScheduleAvailabilityId = scheduleAvailabilities[13].ScheduleAvailabilityId },
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = studentPublicSchoolClasses[1].StudentPublicSchoolClassId, ScheduleAvailabilityId = scheduleAvailabilities[14].ScheduleAvailabilityId },
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = studentPublicSchoolClasses[2].StudentPublicSchoolClassId, ScheduleAvailabilityId = scheduleAvailabilities[15].ScheduleAvailabilityId },
            };

            foreach (PublicSchoolClassSchedule s in publicSchoolClassSchedules)
            {
                context.PublicSchoolClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding publicSchoolClassSchedules End
        }
    }
}
