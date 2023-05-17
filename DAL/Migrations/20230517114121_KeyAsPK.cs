using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class KeyAsPK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "some user");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "VW5rbm93bg==",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Unknown");

            migrationBuilder.CreateTable(
                name: "KeyTest",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyTest", x => x.Key);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Username", "Password", "Type" },
                values: new object[,]
                {
                    { "c29tZSB1c2Vy", "bm9uZQ==", "Anonymouse" },
                    { "YWRtaW4=", "YWRtaW4=", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyTest");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "c29tZSB1c2Vy");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Username",
                keyValue: "YWRtaW4=");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "People",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Unknown",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "VW5rbm93bg==");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Username", "Password", "Type" },
                values: new object[,]
                {
                    { "admin", "YWRtaW4=", "Admin" },
                    { "some user", "bm9uZQ==", "Anonymouse" }
                });
        }
    }
}
