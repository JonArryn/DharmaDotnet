using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DharmaServerDotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class updatebookandauthorrelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Library_LibraryModelId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Library_LibraryModelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "LibraryModelId",
                table: "User",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LibraryModelId",
                table: "User",
                newName: "IX_User_LibraryId");

            migrationBuilder.RenameColumn(
                name: "LibraryModelId",
                table: "Book",
                newName: "LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_LibraryModelId",
                table: "Book",
                newName: "IX_Book_LibraryId");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Library_LibraryId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Library_LibraryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "User",
                newName: "LibraryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_User_LibraryId",
                table: "User",
                newName: "IX_User_LibraryModelId");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Book",
                newName: "LibraryModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Book_LibraryId",
                table: "Book",
                newName: "IX_Book_LibraryModelId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Library_LibraryModelId",
                table: "Book",
                column: "LibraryModelId",
                principalTable: "Library",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Library_LibraryModelId",
                table: "User",
                column: "LibraryModelId",
                principalTable: "Library",
                principalColumn: "Id");
        }
    }
}
