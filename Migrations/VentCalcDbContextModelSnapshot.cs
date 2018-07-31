﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VentCalc.Persistence;

namespace VentCalc.Migrations
{
    [DbContext(typeof(VentCalcDbContext))]
    partial class VentCalcDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VentCalc.Models.BuildingKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuildingKindName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("BuildingKinds");
                });

            modelBuilder.Entity("VentCalc.Models.BuildingPurpose", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingKindId");

                    b.Property<string>("BuildingPurposeName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BuildingKindId");

                    b.ToTable("BuildingPurposes");
                });

            modelBuilder.Entity("VentCalc.Models.BuildingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingPurposeId");

                    b.Property<string>("BuildingTypeName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BuildingPurposeId");

                    b.ToTable("BuildingTypes");
                });

            modelBuilder.Entity("VentCalc.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("RegionId");

                    b.Property<double>("TempOutSummer");

                    b.Property<double>("TempOutWinter");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NormativeDocumentName")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("NormativeDocumentTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NormativeDocumentTypeId");

                    b.ToTable("NormativeDocuments");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocumentRoomTypeLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("NormativeDocumentId");

                    b.Property<int>("RoomTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NormativeDocumentId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("NormativeDocumentRoomTypeLinks");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("NormativeDocumentTypes");
                });

            modelBuilder.Entity("VentCalc.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VentCalc.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("VentCalc.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("Area");

                    b.Property<int>("CityId");

                    b.Property<int?>("Floor");

                    b.Property<double?>("Height");

                    b.Property<double?>("Length");

                    b.Property<int?>("PeopleAmount");

                    b.Property<int>("ProjectId");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("RoomNumber");

                    b.Property<int>("RoomTypeId");

                    b.Property<int?>("UserId");

                    b.Property<double?>("Width");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("VentCalc.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingTypeId");

                    b.Property<string>("RoomTypeName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("BuildingTypeId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("VentCalc.Models.RoomTypeValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(255);

                    b.Property<double?>("Exhaust");

                    b.Property<double?>("ExhaustArea");

                    b.Property<double?>("ExhaustMultiply");

                    b.Property<double?>("ExhaustPeople");

                    b.Property<double?>("HumidityFrom");

                    b.Property<double?>("HumidityRelative");

                    b.Property<double?>("HumidityTo");

                    b.Property<double?>("Inflow");

                    b.Property<double?>("InflowArea");

                    b.Property<double?>("InflowMultiply");

                    b.Property<double?>("InflowPeople");

                    b.Property<int>("RoomTypeId");

                    b.Property<double?>("TempIn");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomTypeValues");
                });

            modelBuilder.Entity("VentCalc.Models.BuildingPurpose", b =>
                {
                    b.HasOne("VentCalc.Models.BuildingKind", "BuildingKind")
                        .WithMany("BuildingPurposes")
                        .HasForeignKey("BuildingKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.BuildingType", b =>
                {
                    b.HasOne("VentCalc.Models.BuildingPurpose", "BuildingPurpose")
                        .WithMany("BuildingTypes")
                        .HasForeignKey("BuildingPurposeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.City", b =>
                {
                    b.HasOne("VentCalc.Models.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocument", b =>
                {
                    b.HasOne("VentCalc.Models.NormativeDocumentType", "NormativeDocumentTypes")
                        .WithMany("NormativeDocuments")
                        .HasForeignKey("NormativeDocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocumentRoomTypeLink", b =>
                {
                    b.HasOne("VentCalc.Models.NormativeDocument", "NormativeDocument")
                        .WithMany()
                        .HasForeignKey("NormativeDocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VentCalc.Models.RoomType", "RoomType")
                        .WithMany()
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.Room", b =>
                {
                    b.HasOne("VentCalc.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VentCalc.Models.Project", "Project")
                        .WithMany("Rooms")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("VentCalc.Models.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.RoomType", b =>
                {
                    b.HasOne("VentCalc.Models.BuildingType", "BuildingType")
                        .WithMany("RoomTypes")
                        .HasForeignKey("BuildingTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.RoomTypeValue", b =>
                {
                    b.HasOne("VentCalc.Models.RoomType", "RoomType")
                        .WithMany("RoomTypeValues")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
