using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class RenamedScheduleToScheduleAvailabilityAddedToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedule_Schedule_ScheduleId",
                table: "ClassSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicSchoolClassSchedule_Schedule_ScheduleId",
                table: "PublicSchoolClassSchedule");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "PublicSchoolClassSchedule",
                newName: "ScheduleAvailabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicSchoolClassSchedule_ScheduleId",
                table: "PublicSchoolClassSchedule",
                newName: "IX_PublicSchoolClassSchedule_ScheduleAvailabilityId");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "ClassSchedule",
                newName: "ScheduleAvailabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSchedule_ScheduleId",
                table: "ClassSchedule",
                newName: "IX_ClassSchedule_ScheduleAvailabilityId");

            migrationBuilder.AddColumn<int>(
                name: "EnglishLevel",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ITLevel",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ScheduleAvailability",
                columns: table => new
                {
                    ScheduleAvailabilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAvailability", x => x.ScheduleAvailabilityId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_ScheduleAvailability_ScheduleAvailabilityId",
                table: "ClassSchedule",
                column: "ScheduleAvailabilityId",
                principalTable: "ScheduleAvailability",
                principalColumn: "ScheduleAvailabilityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicSchoolClassSchedule_ScheduleAvailability_ScheduleAvailabilityId",
                table: "PublicSchoolClassSchedule",
                column: "ScheduleAvailabilityId",
                principalTable: "ScheduleAvailability",
                principalColumn: "ScheduleAvailabilityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassSchedule_ScheduleAvailability_ScheduleAvailabilityId",
                table: "ClassSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_PublicSchoolClassSchedule_ScheduleAvailability_ScheduleAvailabilityId",
                table: "PublicSchoolClassSchedule");

            migrationBuilder.DropTable(
                name: "ScheduleAvailability");

            migrationBuilder.DropColumn(
                name: "EnglishLevel",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "ITLevel",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "ScheduleAvailabilityId",
                table: "PublicSchoolClassSchedule",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_PublicSchoolClassSchedule_ScheduleAvailabilityId",
                table: "PublicSchoolClassSchedule",
                newName: "IX_PublicSchoolClassSchedule_ScheduleId");

            migrationBuilder.RenameColumn(
                name: "ScheduleAvailabilityId",
                table: "ClassSchedule",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassSchedule_ScheduleAvailabilityId",
                table: "ClassSchedule",
                newName: "IX_ClassSchedule_ScheduleId");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<int>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.ScheduleId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassSchedule_Schedule_ScheduleId",
                table: "ClassSchedule",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicSchoolClassSchedule_Schedule_ScheduleId",
                table: "PublicSchoolClassSchedule",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "ScheduleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
