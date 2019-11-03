using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class DeletedClassInstructorLinkedClassToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassInstructor");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "Attendance");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Note",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstructorUserId",
                table: "Class",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicantRating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_ApplicationUserId",
                table: "Note",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_InstructorUserId",
                table: "Class",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_ApplicationUserId",
                table: "ApplicantRating",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_ApplicationUserId",
                table: "ApplicantRating",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Class_AspNetUsers_InstructorUserId",
                table: "Class",
                column: "InstructorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_AspNetUsers_ApplicationUserId",
                table: "Note",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Class_AspNetUsers_InstructorUserId",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_ApplicationUserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ApplicationUserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Class_InstructorUserId",
                table: "Class");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantRating_ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "InstructorUserId",
                table: "Class");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeOut",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
        }
    }
}
