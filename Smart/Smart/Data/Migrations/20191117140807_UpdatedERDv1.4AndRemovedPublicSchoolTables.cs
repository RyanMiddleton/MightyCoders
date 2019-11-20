using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class UpdatedERDv14AndRemovedPublicSchoolTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicSchoolClassSchedule");

            migrationBuilder.DropTable(
                name: "StudentPublicSchoolClass");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Term");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "StudentAssessment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDateTime",
                table: "StudentAssessment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RatingCriteria",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCoreRequirement",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaughtHere",
                table: "Course",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssessment_FileId",
                table: "StudentAssessment",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAssessment_File_FileId",
                table: "StudentAssessment",
                column: "FileId",
                principalTable: "File",
                principalColumn: "FileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentAssessment_File_FileId",
                table: "StudentAssessment");

            migrationBuilder.DropIndex(
                name: "IX_StudentAssessment_FileId",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "SubmissionDateTime",
                table: "StudentAssessment");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "RatingCriteria");

            migrationBuilder.DropColumn(
                name: "IsCoreRequirement",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "IsTaughtHere",
                table: "Course");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Term",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentPublicSchoolClass",
                columns: table => new
                {
                    StudentPublicSchoolClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true),
                    StudentId = table.Column<int>(nullable: false)
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
                name: "PublicSchoolClassSchedule",
                columns: table => new
                {
                    PublicSchoolClassScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduleAvailabilityId = table.Column<int>(nullable: false),
                    StudentPublicSchoolClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicSchoolClassSchedule", x => x.PublicSchoolClassScheduleId);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_ScheduleAvailability_ScheduleAvailabilityId",
                        column: x => x.ScheduleAvailabilityId,
                        principalTable: "ScheduleAvailability",
                        principalColumn: "ScheduleAvailabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicSchoolClassSchedule_StudentPublicSchoolClass_StudentPublicSchoolClassId",
                        column: x => x.StudentPublicSchoolClassId,
                        principalTable: "StudentPublicSchoolClass",
                        principalColumn: "StudentPublicSchoolClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_ScheduleAvailabilityId",
                table: "PublicSchoolClassSchedule",
                column: "ScheduleAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicSchoolClassSchedule_StudentPublicSchoolClassId",
                table: "PublicSchoolClassSchedule",
                column: "StudentPublicSchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPublicSchoolClass_StudentId",
                table: "StudentPublicSchoolClass",
                column: "StudentId");
        }
    }
}
