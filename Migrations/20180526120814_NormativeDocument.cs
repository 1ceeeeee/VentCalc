using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class NormativeDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_BuildingTypes_BuildingTypeId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BuildingTypeId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "Rooms");

            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "RoomTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NormativeDocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormativeDocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NormativeDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NormativeDocumentName = table.Column<string>(maxLength: 1000, nullable: false),
                    NormativeDocumentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormativeDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormativeDocuments_NormativeDocumentTypes_NormativeDocumentTypeId",
                        column: x => x.NormativeDocumentTypeId,
                        principalTable: "NormativeDocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_BuildingTypeId",
                table: "RoomTypes",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NormativeDocuments_NormativeDocumentTypeId",
                table: "NormativeDocuments",
                column: "NormativeDocumentTypeId");
            migrationBuilder.Sql("UPDATE RoomTypes SET BuildingTypeId = 1");
            migrationBuilder.AddForeignKey(
                name: "FK_RoomTypes_BuildingTypes_BuildingTypeId",
                table: "RoomTypes",
                column: "BuildingTypeId",
                principalTable: "BuildingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomTypes_BuildingTypes_BuildingTypeId",
                table: "RoomTypes");

            migrationBuilder.DropTable(
                name: "NormativeDocuments");

            migrationBuilder.DropTable(
                name: "NormativeDocumentTypes");

            migrationBuilder.DropIndex(
                name: "IX_RoomTypes_BuildingTypeId",
                table: "RoomTypes");

            migrationBuilder.DropColumn(
                name: "BuildingTypeId",
                table: "RoomTypes");

            migrationBuilder.AddColumn<int>(
                name: "BuildingTypeId",
                table: "Rooms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingTypeId",
                table: "Rooms",
                column: "BuildingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_BuildingTypes_BuildingTypeId",
                table: "Rooms",
                column: "BuildingTypeId",
                principalTable: "BuildingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
