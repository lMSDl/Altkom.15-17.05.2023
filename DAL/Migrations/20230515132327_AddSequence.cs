using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "NumbersSequence",
                startValue: 150L,
                incrementBy: 33,
                minValue: 100L,
                maxValue: 200L,
                cyclic: true);

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "People",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR NumbersSequence",
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "NumbersSequence");

            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "People",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "NEXT VALUE FOR NumbersSequence");
        }
    }
}
