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
            var _roleManager = roleManager;

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
                roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync(SD.InstructorUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.InstructorUser
                };
                roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync(SD.RaterUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.RaterUser
                };
                roleManager.CreateAsync(role);
            }
            if (!roleManager.RoleExistsAsync(SD.SocialWorkerUser).Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = SD.SocialWorkerUser
                };
                roleManager.CreateAsync(role);
            }
            // Seeding Roles End

            // Seeding User Start
            if (userManager.FindByEmailAsync("admin@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Morgan";
                user.LastName = "Freeman";
                user.UserName = "MorganFreeman";
                user.Email = "admin@mail.com";
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.AdminUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("instructor1@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "George";
                user.LastName = "Feeny";
                user.UserName = "Feeny";
                user.Email = "instructor1@mail.com";
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.InstructorUser).Wait();
                    userManager.AddToRoleAsync(user, SD.RaterUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("instructor2@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Walter";
                user.LastName = "White";
                user.UserName = "Heisenberg";
                user.Email = "instructor2@mail.com";
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.InstructorUser).Wait();
                    userManager.AddToRoleAsync(user, SD.RaterUser).Wait();
                }
            }
            if (userManager.FindByEmailAsync("socialworker@mail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Kenneth";
                user.LastName = "Parcell";
                user.UserName = "Kenny";
                user.Email = "socialworkder@mail.com";
                IdentityResult result = userManager.CreateAsync(user, "Secret123$").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, SD.SocialWorkerUser).Wait();
                }
            }
            // Seeding User End

            // Seeding Term Start
            var terms = new Term[]
            {
                new Term { Description = "Spring2020", StartDate = DateTime.Parse("2020-02-01"), EndDate = DateTime.Parse("2020-06-30"), TimeOfYear = 1},
                new Term { Description = "Fall2020", StartDate = DateTime.Parse("2020-08-01"), EndDate = DateTime.Parse("2020-11-30"), TimeOfYear = 2},
                new Term { Description = "Spring2021", StartDate = DateTime.Parse("2021-02-01"), EndDate = DateTime.Parse("2021-06-30"), TimeOfYear = 1},
                new Term { Description = "Fall2021", StartDate = DateTime.Parse("2021-08-01"), EndDate = DateTime.Parse("2021-11-30"), TimeOfYear = 2},
                //new Term { Description = , StartDate = , EndDate = , TimeOfYear = },
            };

            foreach (Term s in terms)
            {
                context.Term.Add(s);
            }
            context.SaveChanges();
            // Seeding Term End

            // Seeding StudentStatus Start
            var studentStatuses = new StudentStatus[]
            {
                new StudentStatus { Description = "Applied"},
                new StudentStatus { Description = "Accepted"},
                new StudentStatus { Description = "Denied"},
                new StudentStatus { Description = "Waitlisted"}
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
                //new Student { FirstName = , LastName = , DOB = , Address = , Village = , GpsLatitude = , GpsLongitude = , EnrolledDate = , PublicSchoolLevel = , GuardianName = , GuardianType = , Phone = , Photo = , StudentStatusId =  },
                new Student { FirstName = "Aye", LastName = "Student", DOB = DateTime.Parse("1999-01-02"), Address = "Aye Place 01", Village = "Aye Village", GpsLatitude = 0.0, GpsLongitude = 0.01, PublicSchoolLevel = 4, GuardianName = "James", GuardianType = "Father", Phone = "160-532-3452", Photo = null, StudentStatusId = 1},
                new Student { FirstName = "Ayesecond", LastName = "Student", DOB = DateTime.Parse("2000-01-02"), Address = "Aye Place 02", Village = "Aye Village", GpsLatitude = 0.2, GpsLongitude = 0.02, PublicSchoolLevel = 4, GuardianName = "Hela", GuardianType = "Father", Phone = "423-542-4231", Photo = null, StudentStatusId = 2 },
                new Student { FirstName = "Ayethird", LastName = "Student", DOB = DateTime.Parse("2001-01-02"), Address = "Aye Place 03", Village = "Aynotha Village", GpsLatitude = 0.1, GpsLongitude = 0.03, PublicSchoolLevel = 4, GuardianName = "Shela", GuardianType = "Mother", Phone = "543-532-5663", Photo = null, StudentStatusId =  2}
           };

            foreach (Student s in students)
            {
                context.Student.Add(s);
            }
            context.SaveChanges();
            // Seeding Student End

            // Seeding StudentAssessment Start
            var studentAssessments = new StudentAssessment[]
            {
                new StudentAssessment { StudentId = 1, PointsAwarded = 100},
                new StudentAssessment { StudentId = 2, PointsAwarded = 100},
                new StudentAssessment { StudentId = 3, PointsAwarded = 100}
            };

            foreach (StudentAssessment s in studentAssessments)
            {
                context.StudentAssessment.Add(s);
            }
            context.SaveChanges();
            // Seeding StudentAssessment End

            // Seeding RatingCriteria Start
            var ratingCriterias = new RatingCriteria[]
            {
                new RatingCriteria { Description = "ACritieria", MaxScore = 50},
                new RatingCriteria { Description = "AnothaCritieria", MaxScore = 50}
                //new RatingCriteria { Description = "", MaxScore = 50}
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
                new ApplicantRating { StudentId = 1, UserId = 1, RatingCriteriaId = 1, TermId = 1, ScoreAssigned = 48, DateTime = DateTime.Parse("2019-10-30"), Comment = "Acomment"},
                new ApplicantRating { StudentId = 2, UserId = 1, RatingCriteriaId = 2, TermId = 1, ScoreAssigned = 47, DateTime = DateTime.Parse("2019-10-29"), Comment = "comment"},
                new ApplicantRating { StudentId = 3, UserId = 1, RatingCriteriaId = 1, TermId = 3, ScoreAssigned = 49, DateTime = DateTime.Parse("2019-10-28"), Comment = "Ahcomment"},

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
                new Course { Name = "Science"},
                new Course { Name = "Math"},
                new Course { Name = "English"},
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
                new Class { CourseId = 1, TermId = 1, Capacity = 15},
                new Class { CourseId = 2, TermId = 1, Capacity = 20},
                new Class { CourseId = 3, TermId = 2, Capacity = 15},
                new Class { CourseId = 1, TermId = 2, Capacity = 25},
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
                new StudentClass { ClassId = 1, StudentId = 2},
                new StudentClass { ClassId = 2, StudentId = 3},
                new StudentClass { ClassId = 2, StudentId = 1},
                new StudentClass { ClassId = 3, StudentId = 2},
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
                new Assessment { ClassId = 1, Title = "Exam1", Description = "Difficult Exam" , PointsPossible = 100 },
                new Assessment { ClassId = 1, Title = "Exam2", Description = "More Difficult Exam" , PointsPossible = 100 },
                new Assessment { ClassId = 2, Title = "Exam1", Description = "Easy Exam" , PointsPossible = 100 },
                new Assessment { ClassId = 2, Title = "Exam2", Description = "Less Easy Exam" , PointsPossible = 100 },
            };

            foreach (Assessment s in assessments)
            {
                context.Assessment.Add(s);
            }
            context.SaveChanges();
            // Seeding Assessment End

            // Seeding AttendanceStatus Start
            var attendanceStatuses = new AttendanceStatus[]
            {
                new AttendanceStatus { Description = "On Time"},
                new AttendanceStatus { Description = "Late"},
                new AttendanceStatus { Description = "Absent"},
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
                new Attendance { StudentId = 1, ClassId = 1, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("11:00:00"), TimeOut = DateTime.Parse("12:00:00"), AttendanceStatusId = 1 },
                new Attendance { StudentId = 2, ClassId = 2, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("14:00:00"), TimeOut = DateTime.Parse("15:00:00"), AttendanceStatusId = 1 },
                new Attendance { StudentId = 3, ClassId = 1, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("15:00:00"), TimeOut = DateTime.Parse("16:00:00"), AttendanceStatusId = 1 },
                new Attendance { StudentId = 1, ClassId = 2, Date = DateTime.Parse("2020-03-13"), TimeIn = DateTime.Parse("16:00:00"), TimeOut = DateTime.Parse("17:00:00"), AttendanceStatusId = 1 },
            };

            foreach (Attendance s in attendances)
            {
                context.Attendance.Add(s);
            }
            context.SaveChanges();
            // Seeding Attendance End

            // Seeding ClassInstructor Start
            var classInstructors = new ClassInstructor[]
            {
                new ClassInstructor { ClassId = 1, UserId = 2},
                new ClassInstructor { ClassId = 2, UserId = 2},
                new ClassInstructor { ClassId = 3, UserId = 1},
                new ClassInstructor { ClassId = 4, UserId = 1},
            };

            foreach (ClassInstructor s in classInstructors)
            {
                context.ClassInstructor.Add(s);
            }
            context.SaveChanges();
            // Seeding ClassInstructor End

            // Seeding ClassSchedule Start
            var classSchedules = new ClassSchedule[]
            {
                new ClassSchedule { ClassId = 1, ScheduleId = 1},
                new ClassSchedule { ClassId = 1, ScheduleId = 1},
                new ClassSchedule { ClassId = 3, ScheduleId = 1},
                new ClassSchedule { ClassId = 4, ScheduleId = 1}
            };

            foreach (ClassSchedule s in classSchedules)
            {
                context.ClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding ClassSchedule End

            // Seeding FileType Start
            var fileTypes = new FileType[]
            {
                new FileType { Description = "Application"},
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
                new File { StudentId = 1, Path = "PathToFile1", FileTypeId = 1},
                new File { StudentId = 2, Path = "PathToFile2", FileTypeId = 1},
                new File { StudentId = 3, Path = "PathToFile3", FileTypeId = 1},
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
                new NoteType { Description = "ApplicationProcess"},
                new NoteType { Description = "InstructorNote"},
                new NoteType { Description = "SocialWorkerNote"},
            };

            foreach (NoteType s in noteTypes)
            {
                context.NoteType.Add(s);
            }
            context.SaveChanges();
            // Seeding NoteType End

            // Seeding NoteType Start 
            var notes = new Note[]
            {
                new Note { StudentId = 1, UserId = 2, NoteTypeId = 1, Text = "Note on Applicaition"},
                new Note { StudentId = 2, UserId = 2, NoteTypeId = 2, Text = "Note from Instructor"},
                new Note { StudentId = 3, UserId = 2, NoteTypeId = 2, Text = "Note from Instructor"},
            };

            foreach (Note s in notes)
            {
                context.Note.Add(s);
            }
            context.SaveChanges();
            // Seeding NoteType End

            // Seeding studentPublicSchoolClasses Start
            var studentPublicSchoolClasses = new StudentPublicSchoolClass[]
            {
                new StudentPublicSchoolClass { StudentId = 1, CourseName = "Gym"},
                new StudentPublicSchoolClass { StudentId = 2, CourseName = "Gym"},
                new StudentPublicSchoolClass { StudentId = 3, CourseName = "Cooking"},
            };

            foreach (StudentPublicSchoolClass s in studentPublicSchoolClasses)
            {
                context.StudentPublicSchoolClass.Add(s);
            }
            context.SaveChanges();
            // Seeding studentPublicSchoolClasses End

            // Seeding Schedule Start
            var schedules = new Schedule[]
            {
                new Schedule { DayOfWeek = 1, StartTime = DateTime.Parse("13:00:00"), EndTime = DateTime.Parse("14:00:00")},
                new Schedule { DayOfWeek = 2, StartTime = DateTime.Parse("12:00:00"), EndTime = DateTime.Parse("13:00:00")},
                new Schedule { DayOfWeek = 3, StartTime = DateTime.Parse("11:00:00"), EndTime = DateTime.Parse("12:00:00")},
            };

            foreach (Schedule s in schedules)
            {
                context.Schedule.Add(s);
            }
            context.SaveChanges();
            // Seeding Schedule End

            // Seeding publicSchoolClassSchedules Start
            var publicSchoolClassSchedules = new PublicSchoolClassSchedule[]
            {
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = 1, ScheduleId = 1},
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = 2, ScheduleId = 1},
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = 3, ScheduleId = 2},
                new PublicSchoolClassSchedule { StudentPublicSchoolClassId = 3, ScheduleId = 2},
            };

            foreach (PublicSchoolClassSchedule s in publicSchoolClassSchedules)
            {
                context.PublicSchoolClassSchedule.Add(s);
            }
            context.SaveChanges();
            // Seeding publicSchoolClassSchedules End

            /*// Seeding Role Start
            var roles = new Role[]
            {
                //new Role { Name = },
                new Role { Name = "Instructor"},
                new Role { Name = "Rater"},
                new Role { Name = "Admin"}
            };

            foreach (Role s in roles)
            {
                context.Role.Add(s);
            }
            context.SaveChanges();
            // Seeding Role End*/

            context.SaveChanges();
            // Seeding UserRole End
        }
    }
}
