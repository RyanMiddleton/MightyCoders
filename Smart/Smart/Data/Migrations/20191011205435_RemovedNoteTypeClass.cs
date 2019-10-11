using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class RemovedNoteTypeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Note_NoteType_NoteTypeId",
                table: "Note");

            migrationBuilder.DropTable(
                name: "NoteType");

            migrationBuilder.DropIndex(
                name: "IX_Note_NoteTypeId",
                table: "Note");

            migrationBuilder.DropColumn(
                name: "NoteTypeId",
                table: "Note");

            migrationBuilder.AddColumn<string>(
                name: "NoteType",
                table: "Note",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoteType",
                table: "Note");

            migrationBuilder.AddColumn<int>(
                name: "NoteTypeId",
                table: "Note",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteTypeId",
                table: "Note",
                column: "NoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_NoteType_NoteTypeId",
                table: "Note",
                column: "NoteTypeId",
                principalTable: "NoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
