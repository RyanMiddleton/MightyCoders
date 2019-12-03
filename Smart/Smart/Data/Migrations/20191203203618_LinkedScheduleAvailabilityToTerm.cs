using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class LinkedScheduleAvailabilityToTerm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TermId",
                table: "ScheduleAvailability",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAvailability_TermId",
                table: "ScheduleAvailability",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleAvailability_Term_TermId",
                table: "ScheduleAvailability",
                column: "TermId",
                principalTable: "Term",
                principalColumn: "TermId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleAvailability_Term_TermId",
                table: "ScheduleAvailability");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleAvailability_TermId",
                table: "ScheduleAvailability");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "ScheduleAvailability");
        }
    }
}
