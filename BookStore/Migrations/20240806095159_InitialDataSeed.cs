using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Biography", "Name" },
                values: new object[] { 1, "Chetan Bhagat is a bestselling Indian author and columnist known for his novels that explore contemporary Indian society and youth culture. He is also a motivational speaker and a former investment banker. Some of his popular works include \"Five Point Someone,\" \"2 States,\" and \"The 3 Mistakes of My Life.\"", "Chetan Bhagat" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[] { 1, "Self-Help" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "GenreId", "Price", "PublicationDate", "Title" },
                values: new object[] { 1, 1, 1, 9.99m, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "11 Rules of Life" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);
        }
    }
}
