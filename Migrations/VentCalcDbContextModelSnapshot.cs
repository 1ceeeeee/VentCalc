﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("VentCalc.Models.AppUserRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<string>("AppUsersId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<int>("RightId");

                    b.Property<int?>("RightsId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("AppUsersId");

                    b.HasIndex("RightsId");

                    b.ToTable("AppUserRights");
                });

            modelBuilder.Entity("VentCalc.Models.BuildingKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BuildingKindName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

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

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

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

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

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

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<int>("RegionId");

                    b.Property<double>("TempOutSummer");

                    b.Property<double>("TempOutWinter");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("VentCalc.Models.HeatingVentilationSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AirCoolerAmount");

                    b.Property<double?>("AirCoolerColdConsumption");

                    b.Property<double?>("AirCoolerCoolingTempFrom");

                    b.Property<double?>("AirCoolerCoolingTempTo");

                    b.Property<double?>("AirCoolerResistance");

                    b.Property<string>("AirCoolerTypeName")
                        .HasMaxLength(512);

                    b.Property<int?>("AirHeaterAmount");

                    b.Property<double?>("AirHeaterHeatingTempFrom");

                    b.Property<double?>("AirHeaterHeatingTempTo");

                    b.Property<double?>("AirHeaterPowerConsumption");

                    b.Property<double?>("AirHeaterResistanceAir");

                    b.Property<double?>("AirHeaterResistanceWater");

                    b.Property<string>("AirHeaterTypeName")
                        .HasMaxLength(512);

                    b.Property<string>("Comment")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<double?>("FanAirConsumption");

                    b.Property<double?>("FanHead");

                    b.Property<double?>("FanMotorPower");

                    b.Property<double?>("FanMotorSpeed");

                    b.Property<string>("FanMotorTypeName")
                        .HasMaxLength(512);

                    b.Property<double?>("FanSpeed");

                    b.Property<string>("FanTypeName")
                        .HasMaxLength(512);

                    b.Property<int?>("FilterAmount");

                    b.Property<double?>("FilterResistance");

                    b.Property<string>("FilterTypeName")
                        .HasMaxLength(512);

                    b.Property<string>("InstallTypeName")
                        .HasMaxLength(512);

                    b.Property<int>("ProjectId");

                    b.Property<double?>("RecuperatorAirConsumptionHeated");

                    b.Property<double?>("RecuperatorAirConsumptionHeating");

                    b.Property<int?>("RecuperatorAmount");

                    b.Property<double?>("RecuperatorEfficiency");

                    b.Property<double?>("RecuperatorHeatingTempFrom");

                    b.Property<double?>("RecuperatorHeatingTempTo");

                    b.Property<double?>("RecuperatorPowerConsumption");

                    b.Property<double?>("RecuperatorResistanceHeated");

                    b.Property<double?>("RecuperatorResistanceHeating");

                    b.Property<string>("RecuperatorTypeName")
                        .HasMaxLength(512);

                    b.Property<string>("RoomName")
                        .HasMaxLength(4000);

                    b.Property<int?>("SystemAmount");

                    b.Property<string>("SystemName")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("HeatingVentilationSystems");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("NormativeDocumentName")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<int>("NormativeDocumentTypeId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("NormativeDocumentTypeId");

                    b.ToTable("NormativeDocuments");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocumentRoomTypeLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<int>("NormativeDocumentId");

                    b.Property<int>("RoomTypeId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("NormativeDocumentId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("NormativeDocumentRoomTypeLinks");
                });

            modelBuilder.Entity("VentCalc.Models.NormativeDocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.ToTable("NormativeDocumentTypes");
                });

            modelBuilder.Entity("VentCalc.Models.PortalUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IdentityId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("PortalUsers");
                });

            modelBuilder.Entity("VentCalc.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CityId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VentCalc.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("VentCalc.Models.Rights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("VentCalc.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("Area");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<double?>("ExhaustCalc");

                    b.Property<string>("ExhaustSystem")
                        .HasMaxLength(255);

                    b.Property<int?>("Floor");

                    b.Property<double?>("Height");

                    b.Property<double?>("InflowCalc");

                    b.Property<string>("InflowSystem")
                        .HasMaxLength(255);

                    b.Property<double?>("Length");

                    b.Property<int?>("PeopleAmount");

                    b.Property<int>("ProjectId");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("RoomNumber");

                    b.Property<int>("RoomTypeId");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.Property<double?>("Volume");

                    b.Property<double?>("Width");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("VentCalc.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BuildingTypeId");

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("RoomTypeName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

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

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

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

                    b.Property<int>("RoomTypeValueConditionId");

                    b.Property<double?>("TempIn");

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomTypeValues");
                });

            modelBuilder.Entity("VentCalc.Models.RoomTypeValueCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CreateDate");

                    b.Property<int?>("CreateUserId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<int?>("DeleteUsertId");

                    b.Property<string>("RoomTypeValueConditionName")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("UpdateDate");

                    b.Property<int?>("UpdateUserId");

                    b.HasKey("Id");

                    b.ToTable("RoomTypeValueConditions");
                });

            modelBuilder.Entity("VentCalc.Models.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("SecondName");

                    b.ToTable("AppUser");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("VentCalc.Models.AppUserRights", b =>
                {
                    b.HasOne("VentCalc.Models.AppUser", "AppUsers")
                        .WithMany("Rights")
                        .HasForeignKey("AppUsersId");

                    b.HasOne("VentCalc.Models.Rights", "Rights")
                        .WithMany("Users")
                        .HasForeignKey("RightsId");
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

            modelBuilder.Entity("VentCalc.Models.HeatingVentilationSystem", b =>
                {
                    b.HasOne("VentCalc.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
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

            modelBuilder.Entity("VentCalc.Models.PortalUser", b =>
                {
                    b.HasOne("VentCalc.Models.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("VentCalc.Models.Project", b =>
                {
                    b.HasOne("VentCalc.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("VentCalc.Models.Room", b =>
                {
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
