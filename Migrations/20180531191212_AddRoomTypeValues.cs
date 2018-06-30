using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class AddRoomTypeValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exhaust",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "HumidityFrom",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "HumidityRelative",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "HumidityTo",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Inflow",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "IsForPeople",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "TempIn",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "RoomTypes");

            migrationBuilder.CreateTable(
                name: "RoomTypeValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(maxLength: 255, nullable: true),
                    Exhaust = table.Column<double>(nullable: false),
                    ExhaustArea = table.Column<double>(nullable: false),
                    ExhaustMultiply = table.Column<double>(nullable: false),
                    ExhaustPeople = table.Column<double>(nullable: false),
                    HumidityFrom = table.Column<double>(nullable: false),
                    HumidityRelative = table.Column<double>(nullable: false),
                    HumidityTo = table.Column<double>(nullable: false),
                    Inflow = table.Column<double>(nullable: false),
                    InflowArea = table.Column<double>(nullable: false),
                    InflowMultiply = table.Column<double>(nullable: false),
                    InflowPeople = table.Column<double>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    TempIn = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypeValues_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeValues_RoomTypeId",
                table: "RoomTypeValues",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypeValues");

            migrationBuilder.AddColumn<double>(
                name: "Exhaust",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HumidityFrom",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HumidityRelative",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "HumidityTo",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Inflow",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsForPeople",
                table: "RoomTypes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TempIn",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "RoomTypes",
                maxLength: 255,
                nullable: true);
        }
    }
}
