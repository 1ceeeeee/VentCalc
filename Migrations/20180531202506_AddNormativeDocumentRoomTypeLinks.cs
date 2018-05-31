using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class AddNormativeDocumentRoomTypeLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormativeDocumentBuildingTypeLinks");

            migrationBuilder.CreateTable(
                name: "NormativeDocumentRoomTypeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NormativeDocumentId = table.Column<int>(nullable: false),
                    RoomTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormativeDocumentRoomTypeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormativeDocumentRoomTypeLinks_NormativeDocuments_NormativeDocumentId",
                        column: x => x.NormativeDocumentId,
                        principalTable: "NormativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormativeDocumentRoomTypeLinks_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormativeDocumentRoomTypeLinks_NormativeDocumentId",
                table: "NormativeDocumentRoomTypeLinks",
                column: "NormativeDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_NormativeDocumentRoomTypeLinks_RoomTypeId",
                table: "NormativeDocumentRoomTypeLinks",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormativeDocumentRoomTypeLinks");

            migrationBuilder.CreateTable(
                name: "NormativeDocumentBuildingTypeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingTypeId = table.Column<int>(nullable: false),
                    NormativeDocumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormativeDocumentBuildingTypeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NormativeDocumentBuildingTypeLinks_BuildingTypes_BuildingTypeId",
                        column: x => x.BuildingTypeId,
                        principalTable: "BuildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormativeDocumentBuildingTypeLinks_NormativeDocuments_NormativeDocumentId",
                        column: x => x.NormativeDocumentId,
                        principalTable: "NormativeDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormativeDocumentBuildingTypeLinks_BuildingTypeId",
                table: "NormativeDocumentBuildingTypeLinks",
                column: "BuildingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NormativeDocumentBuildingTypeLinks_NormativeDocumentId",
                table: "NormativeDocumentBuildingTypeLinks",
                column: "NormativeDocumentId");
        }
    }
}
