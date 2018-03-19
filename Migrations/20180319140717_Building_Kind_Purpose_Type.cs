using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class Building_Kind_Purpose_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingKindName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingPurposes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingKindId = table.Column<int>(nullable: false),
                    BuildingPurposeName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingPurposes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingPurposes_BuildingKinds_BuildingKindId",
                        column: x => x.BuildingKindId,
                        principalTable: "BuildingKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingPurposeId = table.Column<int>(nullable: false),
                    BuildingTypeName = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingTypes_BuildingPurposes_BuildingPurposeId",
                        column: x => x.BuildingPurposeId,
                        principalTable: "BuildingPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingPurposes_BuildingKindId",
                table: "BuildingPurposes",
                column: "BuildingKindId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingTypes_BuildingPurposeId",
                table: "BuildingTypes",
                column: "BuildingPurposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingTypes");

            migrationBuilder.DropTable(
                name: "BuildingPurposes");

            migrationBuilder.DropTable(
                name: "BuildingKinds");
        }
    }
}
