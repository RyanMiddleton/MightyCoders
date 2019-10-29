using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class AllModelsExceptIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Term_TermId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Student_StudentId",
                table: "Note");

            migrationBuilder.DropTable(
                name: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "InstructorName",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "Attended",
                table: "Attendance");

            migrationBuilder.RenameColumn(
                name: "TermName",
                table: "Term",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Term",
                newName: "TermId");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Student",
                newName: "GpsLongitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Student",
                newName: "GpsLatitude");

            migrationBuilder.RenameColumn(
                name: "AddressLine3",
                table: "Student",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Note",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Note",
                newName: "NoteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Class",
                newName: "ClassId");

            migrationBuilder.RenameColumn(
                name: "TermId",
                table: "Attendance",
                newName: "ClassId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_TermId",
                table: "Attendance",
                newName: "IX_Attendance_ClassId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Assessment",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Assessment",
                newName: "AssessmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Term",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Term",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TimeOfYear",
                table: "Term",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentStatusId",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Note",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NoteTypeId",
                table: "Note",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Note",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Class",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Class",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AttendanceStatusId",
                table: "Attendance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeIn",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOut",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PointsPossible",
                table: "Assessment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.CreateTable(
                name: "AttendanceStatus",
                columns: table => new
                {
                    AttendanceStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceStatus", x => x.AttendanceStatusId);
                });

            migrationBuilder.CreateTable(
                name: "ClassInstructor",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassInstructor", x => new { x.ClassId, x.UserId });
                    table.UniqueConstraint("AK_ClassInstructor_ClassId", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_ClassInstructor_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    FileTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.FileTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NoteType",
                columns: table => new
                {
                    NoteTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteType", x => x.NoteTypeId);
                });

            migrationBuilder.CreateTable(
                name: "RatingCriteria",
                columns: table => new
                {
                    RatingCriteriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    MaxScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingCriteria", x => x.RatingCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssessment",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    PointsAwarded = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssessment", x => new { x.AssessmentId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentAssessment_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssessment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClass_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPublicSchoolClass",
                columns: table => new
                {
                    StudentPublicSchoolClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPublicSchoolClass", x => x.StudentPublicSchoolClassId);
                    table.ForeignKey(
                        name: "FK_StudentPublicSchoolClass_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentStatus",
                columns: table => new
                {
                    StudentStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStatus", x => x.StudentStatusId);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    FileTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_File_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantRating",
                columns: table => new
                {
                    ApplicantRatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    RatingCriteriaId = table.Column<int>(nullable: false),
                    TermId = table.Column<int>(nullable: false),
                    ScoreAssigned = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantRating", x => x.ApplicantRatingId);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_RatingCriteria_RatingCriteriaId",
                        column: x => x.RatingCriteriaId,
                        principalTable: "RatingCriteria",
                        principalColumn: "RatingCriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicantRating_Term_TermId",
                        column: x => x.TermId,
                        principalTable: "Term",
                        principalColumn: "TermId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassSchedule",
                columns: table => new
                {
                    ClassId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedule", x => new { x.ClassId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicSchoolClassSchedule",
                columns: table => new
                {
                    PublicSchoolClassScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentPublicSchoolClassId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSchoolClassSchedule", x => x.PublicSchoolClassScheduleId);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_StudentPublicSchoolClass_StudentPublicSchoolClassId",
                        column: x => x.StudentPublicSchoolClassId,
                        principalTable: "StudentPublicSchoolClass",
                        principalColumn: "StudentPublicSchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentStatusId",
                table: "Student",
                column: "StudentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteTypeId",
                table: "Note",
                column: "NoteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_AttendanceStatusId",
                table: "Attendance",
                column: "AttendanceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_RatingCriteriaId",
                table: "ApplicantRating",
                column: "RatingCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_StudentId",
                table: "ApplicantRating",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_TermId",
                table: "ApplicantRating",
                column: "TermId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ScheduleId",
                table: "ClassSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_File_FileTypeId",
                table: "File",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File_StudentId",
                table: "File",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_ScheduleId",
                table: "PublicSchoolClassSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_StudentPublicSchoolClassId",
                table: "PublicSchoolClassSchedule",
                column: "StudentPublicSchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_StudentId",
                table: "StudentAssessment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentClass",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPublicSchoolClass_StudentId",
                table: "StudentPublicSchoolClass",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_AttendanceStatus_AttendanceStatusId",
                table: "Attendance",
                column: "AttendanceStatusId",
                principalTable: "AttendanceStatus",
                principalColumn: "AttendanceStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Class_ClassId",
                table: "Attendance",
                column: "ClassId",
                principalTable: "Class",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Course_CourseId",
                table: "Class",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_NoteType_NoteTypeId",
                table: "Note",
                column: "NoteTypeId",
                principalTable: "NoteType",
                principalColumn: "NoteTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Student_StudentId",
                table: "Note",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentStatus_StudentStatusId",
                table: "Student",
                column: "StudentStatusId",
                principalTable: "StudentStatus",
                principalColumn: "StudentStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_AttendanceStatus_AttendanceStatusId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Class_ClassId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_Course_CourseId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_NoteType_NoteTypeId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Student_StudentId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentStatus_StudentStatusId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "ApplicantRating");

            migrationBuilder.DropTable(
                name: "AttendanceStatus");

            migrationBuilder.DropTable(
                name: "ClassInstructor");

            migrationBuilder.DropTable(
                name: "ClassSchedule");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "NoteType");

            migrationBuilder.DropTable(
                name: "PublicSchoolClassSchedule");

            migrationBuilder.DropTable(
                name: "StudentAssessment");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "StudentStatus");

            migrationBuilder.DropTable(
                name: "RatingCriteria");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "StudentPublicSchoolClass");

            migrationBuilder.DropIndex(
                name: "IX_Student_StudentStatusId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Note_NoteTypeId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Class_CourseId",
                table: "Class");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.DropIndex(
                name: "IX_Attendance_AttendanceStatusId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "TimeOfYear",
                table: "Term");

            migrationBuilder.DropColumn(
                name: "StudentStatusId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "NoteTypeId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "AttendanceStatusId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "PointsPossible",
                table: "Assessment");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Term",
                newName: "TermName");

            migrationBuilder.RenameColumn(
                name: "TermId",
                table: "Term",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GpsLongitude",
                table: "Student",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "GpsLatitude",
                table: "Student",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Student",
                newName: "AddressLine3");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Note",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Note",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Class",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Attendance",
                newName: "TermId");

            migrationBuilder.RenameIndex(
                name: "IX_Attendance_ClassId",
                table: "Attendance",
                newName: "IX_Attendance_TermId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Assessment",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AssessmentId",
                table: "Assessment",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Student",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Note",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Class",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorName",
                table: "Class",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Attendance",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<bool>(
                name: "Attended",
                table: "Attendance",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AssessmentId = table.Column<int>(nullable: false),
                    Score = table.Column<double>(nullable: false),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_Assessment_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grade_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_StudentId",
                table: "Attendance",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_AssessmentId",
                table: "Grade",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_StudentId",
                table: "Grade",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Term_TermId",
                table: "Attendance",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Student_StudentId",
                table: "Note",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
