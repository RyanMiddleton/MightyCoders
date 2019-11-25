using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class LinkedStudentToClassScheduleInseadOfClassAddedSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ClassScheduleId",
                table: "ClassSchedule",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "ClassSchedule",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                column: "ClassScheduleId");

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    SectionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.SectionId);
                });

            migrationBuilder.CreateTable(
                name: "StudentClassSchedule",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    ClassScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassSchedule", x => new { x.StudentId, x.ClassScheduleId });
                    table.ForeignKey(
                        name: "FK_StudentClassSchedule_ClassSchedule_ClassScheduleId",
                        column: x => x.ClassScheduleId,
                        principalTable: "ClassSchedule",
                        principalColumn: "ClassScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClassSchedule_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_ClassId",
                table: "ClassSchedule",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_SectionId",
                table: "ClassSchedule",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassSchedule_ClassScheduleId",
                table: "StudentClassSchedule",
                column: "ClassScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_Section_SectionId",
                table: "ClassSchedule",
                column: "SectionId",
                principalTable: "Section",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedule_Section_SectionId",
                table: "ClassSchedule");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "StudentClassSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedule_ClassId",
                table: "ClassSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ClassSchedule_SectionId",
                table: "ClassSchedule");

            migrationBuilder.DropColumn(
                name: "ClassScheduleId",
                table: "ClassSchedule");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "ClassSchedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassSchedule",
                table: "ClassSchedule",
                columns: new[] { "ClassId", "ScheduleAvailabilityId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_ClassId",
                table: "StudentClass",
                column: "ClassId");
        }
    }
}
