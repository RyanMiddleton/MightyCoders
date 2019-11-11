using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class updatedApplicantRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicantRating",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicantRating",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
