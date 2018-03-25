using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class AddRoom_RoomType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Exhaust = table.Column<double>(nullable: false),
                    HumidityFrom = table.Column<double>(nullable: false),
                    HumidityRelative = table.Column<double>(nullable: false),
                    HumidityTo = table.Column<double>(nullable: false),
                    Inflow = table.Column<double>(nullable: false),
                    IsForPeople = table.Column<bool>(nullable: false),
                    RoomTypeName = table.Column<string>(maxLength: 255, nullable: false),
                    TempIn = table.Column<double>(nullable: false),
                    Unit = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<double>(nullable: false),
                    BuildingTypeId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Length = table.Column<double>(nullable: false),
                    PeopleAmount = table.Column<int>(nullable: false),
                    RoomName = table.Column<string>(maxLength: 255, nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Width = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingTypeId",
                table: "Rooms",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CityId",
                table: "Rooms",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
