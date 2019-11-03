using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class LinkedRatingAndNoteToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_ApplicationUserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_ApplicationUserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantRating_ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ApplicantRating");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Note",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ApplicantRating",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Note_UserId",
                table: "Note",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantRating_UserId",
                table: "ApplicantRating",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Note_AspNetUsers_UserId",
                table: "Note",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantRating_AspNetUsers_UserId",
                table: "ApplicantRating");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_AspNetUsers_UserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_Note_UserId",
                table: "Note");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantRating_UserId",
                table: "ApplicantRating");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Note",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Note",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ApplicantRating",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ApplicantRating",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_ApplicationUserId",
                table: "Note",
                column: "ApplicationUserId");

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
                name: "FK_Note_AspNetUsers_ApplicationUserId",
                table: "Note",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
