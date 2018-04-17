using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class Delete_Volume_InflowCalc_ExhaustCalc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExhaustCalc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "InflowCalc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExhaustCalc",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InflowCalc",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "Rooms",
                nullable: true);
        }
    }
}
