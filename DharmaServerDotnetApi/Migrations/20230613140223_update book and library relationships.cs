using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DharmaServerDotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class updatebookandlibraryrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Library_LibraryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Library_LibraryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LibraryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Book_LibraryId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Book");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_LibraryId",
                table: "User",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LibraryId",
                table: "Book",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Library_LibraryId",
                table: "Book",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Library_LibraryId",
                table: "User",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "Id");
        }
    }
}
