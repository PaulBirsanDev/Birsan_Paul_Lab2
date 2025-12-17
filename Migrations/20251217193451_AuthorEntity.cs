using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birsan_Paul_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class AuthorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_categoryID",
                table: "BookCategory");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "BookCategory",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_categoryID",
                table: "BookCategory",
                newName: "IX_BookCategory_CategoryID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookCategory_Category_CategoryID",
                table: "BookCategory");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "BookCategory",
                newName: "categoryID");

            migrationBuilder.RenameIndex(
                name: "IX_BookCategory_CategoryID",
                table: "BookCategory",
                newName: "IX_BookCategory_categoryID");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookCategory_Category_categoryID",
                table: "BookCategory",
                column: "categoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
