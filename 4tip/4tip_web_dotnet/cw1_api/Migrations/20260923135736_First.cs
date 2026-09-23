using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cw1_api.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "Bolesław Prus", 0m, new DateTime(1890, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lalka" },
                    { 2, "Fiodor Dostojewski", 0m, new DateTime(1866, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zbrodnia i kara" },
                    { 3, "Jane Austen", 0m, new DateTime(1813, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Duma i uprzedzenie" },
                    { 4, "J.R.R. Tolkien", 0m, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Władca Pierścieni" },
                    { 5, "Antoine de Saint-Exupéry", 0m, new DateTime(1943, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mały Książę" },
                    { 6, "George Orwell", 0m, new DateTime(1949, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984" },
                    { 7, "Michaił Bułhakow", 0m, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mistrz i Małgorzata" },
                    { 8, "Gabriel García Márquez", 0m, new DateTime(1967, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sto lat samotności" },
                    { 9, "J.R.R. Tolkien", 0m, new DateTime(1937, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hobbit" },
                    { 10, "Andrzej Sapkowski", 0m, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ostatnie życzenie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
