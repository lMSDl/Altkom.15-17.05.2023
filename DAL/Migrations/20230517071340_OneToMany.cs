﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Vehicle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_EngineId",
                table: "Vehicle",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Engine_EngineId",
                table: "Vehicle",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Engine_EngineId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_EngineId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Vehicle");
        }
    }
}
