using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class AddNormativeDocumentBuildingTypeLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingTypes_NormativeDocuments_NormativeDocumentId",
                table: "BuildingTypes");

            migrationBuilder.DropIndex(
                name: "IX_BuildingTypes_NormativeDocumentId",
                table: "BuildingTypes");

            migrationBuilder.DropColumn(
                name: "NormativeDocumentId",
                table: "BuildingTypes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormativeDocumentBuildingTypeLinks");

            migrationBuilder.AddColumn<int>(
                name: "NormativeDocumentId",
                table: "BuildingTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingTypes_NormativeDocumentId",
                table: "BuildingTypes",
                column: "NormativeDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingTypes_NormativeDocuments_NormativeDocumentId",
                table: "BuildingTypes",
                column: "NormativeDocumentId",
                principalTable: "NormativeDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
