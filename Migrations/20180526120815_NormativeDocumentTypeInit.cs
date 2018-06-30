using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace VentCalc.Migrations
{
    public partial class NormativeDocumentTypeInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'СП')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'СанПиН')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'МГСН')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'РМД')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'ВСН')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'ВНТП')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'ВНП')");
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocumentTypes(Name) VALUES (N'ДБН')");

            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocuments(NormativeDocumentName, NormativeDocumentTypeId) VALUES (N'СП 118.13330.2012 Общественные здания и сооружения', (SELECT Id FROM dbo.NormativeDocumentTypes ndt WHERE ndt.Name = 'СП') )"); 
            migrationBuilder.Sql("INSERT INTO dbo.NormativeDocuments(NormativeDocumentName, NormativeDocumentTypeId) VALUES (N'СП 54.13330.2011 Здания жилые многоквартирные', (SELECT Id FROM dbo.NormativeDocumentTypes ndt WHERE ndt.Name = 'СП')) ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM dbo.NormativeDocuments");
            migrationBuilder.Sql("DELETE FROM dbo.NormativeDocumentTypes");
        }
    }
}
