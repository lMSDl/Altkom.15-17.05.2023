using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneOnDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration");

            migrationBuilder.AddForeignKey(
                name: "FK_Registration_Vehicle_VehicleId",
                table: "Registration",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
