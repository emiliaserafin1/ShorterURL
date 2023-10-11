using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace URLShortener.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ShortUrl", "LongUrl" },
                values: new object[] { "shorturl1", "https://www.example.com/page1" });

            migrationBuilder.InsertData(
                table: "Urls",
                columns: new[] { "ShortUrl", "LongUrl" },
                values: new object[] { "shorturl2", "https://www.example.com/page2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
