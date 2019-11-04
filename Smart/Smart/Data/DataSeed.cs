using Smart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Data
{
    public class DataSeed
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            /*// Look for any students.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }*/

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

            // Seeding User Start
            var users = new ApplicationUser[]
            {
                new ApplicationUser { Email = "user1@mail.com", FirstName = "Aye", LastName = "User"},
                new ApplicationUser { Email = "user2@mail.com", FirstName = "Ayesecond", LastName = "User"},
                new ApplicationUser { Email = "user3@mail.com", FirstName = "Ayethird", LastName = "User"}
            };

            foreach (ApplicationUser s in users)
            {
                context.ApplicationUser.Add(s);
            }
            context.SaveChanges();
            // Seeding User End

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
                new StudentAssessment { PointsAwarded = 100},
                new StudentAssessment { PointsAwarded = 100},
                new StudentAssessment { PointsAwarded = 100}
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
                new ApplicantRating {  /*UserId = 1, RatingCriteriaId = 1, TermId = 1,*/ ScoreAssigned = 48, DateTime = DateTime.Parse("2019-10-30"), Comment = "Acomment"},
                new ApplicantRating {  /*UserId = 1, RatingCriteriaId = 2, TermId = 1, */ScoreAssigned = 47, DateTime = DateTime.Parse("2019-10-29"), Comment = "comment"},
                new ApplicantRating { /*UserId = 1, RatingCriteriaId = 1, TermId = 3,*/ ScoreAssigned = 49, DateTime = DateTime.Parse("2019-10-28"), Comment = "Ahcomment"},

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
                new Class { /*CourseId = 1, TermId = 1,*/ Capacity = 15},
                new Class { /*CourseId = 2, TermId = 1,*/ Capacity = 20},
                new Class { /*CourseId = 3, TermId = 2,*/ Capacity = 15},
                new Class { /*CourseId = 1, TermId = 2,*/ Capacity = 25},
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
                new StudentClass { StudentId = 3},
                new StudentClass { StudentId = 2},
                new StudentClass { StudentId = 2},
                new StudentClass { StudentId = 1},
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
