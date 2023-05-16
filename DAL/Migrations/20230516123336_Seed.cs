using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Username", "Password", "Type" },
                values: new object[,]
                {
                    { "admin", "YWRtaW4=", "Admin" },
                    { "some user", "bm9uZQ==", "Anonymouse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "some user");
        }
    }
}
