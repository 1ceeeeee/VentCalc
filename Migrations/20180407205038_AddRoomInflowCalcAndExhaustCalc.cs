using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class AddRoomInflowCalcAndExhaustCalc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ExhaustCalc",
                table: "Rooms",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "InflowCalc",
                table: "Rooms",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExhaustCalc",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "InflowCalc",
                table: "Rooms");
        }
    }
}
