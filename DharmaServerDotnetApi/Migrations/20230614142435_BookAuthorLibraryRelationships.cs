using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DharmaServerDotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class BookAuthorLibraryRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PenName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookLibrary",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    LibrariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLibrary", x => new { x.BooksId, x.LibrariesId });
                    table.ForeignKey(
                        name: "FK_BookLibrary_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLibrary_Library_LibrariesId",
                        column: x => x.LibrariesId,
                        principalTable: "Library",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookLibrary_LibrariesId",
                table: "BookLibrary",
                column: "LibrariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropTable(
                name: "BookLibrary");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PenName",
                table: "Author");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
