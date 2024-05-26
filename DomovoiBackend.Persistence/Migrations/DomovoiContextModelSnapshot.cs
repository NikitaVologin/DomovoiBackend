﻿// <auto-generated />
using System;
using DomovoiBackend.Persistence.EfSettings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DomovoiBackend.Persistence.Migrations
{
    [DbContext(typeof(DomovoiContext))]
    partial class DomovoiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Announcements.Announcement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConnectionType")
                        .HasColumnType("text");

                    b.Property<Guid?>("CounterAgentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DealId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("RealityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CounterAgentId");

                    b.HasIndex("DealId");

                    b.HasIndex("RealityId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell.Addiction.SellConditions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SellConditions");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Common.ApartmentHouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BuildingYear")
                        .HasColumnType("integer");

                    b.Property<double>("CeilingHeight")
                        .HasColumnType("double precision");

                    b.Property<bool>("HaveGarbageChute")
                        .HasColumnType("boolean");

                    b.Property<bool>("HaveParking")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGas")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsInfrastructure")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLandscaping")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSecurity")
                        .HasColumnType("boolean");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ApartmentHouses");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Common.Elevator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ApartmentHouseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApartmentHouseId");

                    b.ToTable("Elevators");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CounterAgents");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Deal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Deals");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction.RentConditions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("CommunalPays")
                        .HasColumnType("double precision");

                    b.Property<double>("Deposit")
                        .HasColumnType("double precision");

                    b.Property<string>("Period")
                        .HasColumnType("text");

                    b.Property<double>("Prepay")
                        .HasColumnType("double precision");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("RentConditions");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction.RentRules", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanSmoke")
                        .HasColumnType("boolean");

                    b.Property<string>("Facilities")
                        .HasColumnType("text");

                    b.Property<bool>("WithAnimals")
                        .HasColumnType("boolean");

                    b.Property<bool>("WithKids")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("RentRules");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Sell.Addiction.SellFeatures", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("HaveChildOwners")
                        .HasColumnType("boolean");

                    b.Property<bool>("HaveChildPrescribers")
                        .HasColumnType("boolean");

                    b.Property<int>("OwnersCount")
                        .HasColumnType("integer");

                    b.Property<int>("PrescribersCount")
                        .HasColumnType("integer");

                    b.Property<int>("YearInOwn")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SellFeatures");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Building", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("BuildingYear")
                        .HasColumnType("integer");

                    b.Property<string>("CenterName")
                        .HasColumnType("text");

                    b.Property<string>("Class")
                        .HasColumnType("text");

                    b.Property<bool>("HaveParking")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsEquipment")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes.Bathroom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Bathrooms");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.Reality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Area")
                        .HasColumnType("double precision");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Reality", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.CounterAgents.Types.LegalCounterAgent", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Tin")
                        .HasColumnType("text");

                    b.Property<string>("Trc")
                        .HasColumnType("text");

                    b.ToTable("LegalCounterAgent", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.CounterAgents.Types.PhysicalCounterAgent", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent");

                    b.Property<string>("FIO")
                        .HasColumnType("text");

                    b.ToTable("PhysicalCounterAgent", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Rent", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Deals.Deal");

                    b.Property<Guid?>("RentConditionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RentRulesId")
                        .HasColumnType("uuid");

                    b.HasIndex("RentConditionsId");

                    b.HasIndex("RentRulesId");

                    b.ToTable("Rent", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Sell.Sell", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Deals.Deal");

                    b.Property<Guid?>("SellConditionsId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SellFeaturesId")
                        .HasColumnType("uuid");

                    b.HasIndex("SellConditionsId");

                    b.HasIndex("SellFeaturesId");

                    b.ToTable("Sell", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.Areas.Area", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.Reality");

                    b.Property<bool>("Electricity")
                        .HasColumnType("boolean");

                    b.Property<bool>("Gas")
                        .HasColumnType("boolean");

                    b.Property<bool>("Sewage")
                        .HasColumnType("boolean");

                    b.Property<bool>("WaterSupply")
                        .HasColumnType("boolean");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.Reality");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<Guid?>("BuildingId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Entry")
                        .HasColumnType("boolean");

                    b.Property<int>("FloorsCount")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAccess")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUse")
                        .HasColumnType("boolean");

                    b.HasIndex("BuildingId");

                    b.ToTable("CommercialBuilding", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.Garages.Garage", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.Reality");

                    b.Property<bool>("Access")
                        .HasColumnType("boolean");

                    b.Property<bool>("Electricity")
                        .HasColumnType("boolean");

                    b.Property<string>("GKSName")
                        .HasColumnType("text");

                    b.Property<bool>("Heating")
                        .HasColumnType("boolean");

                    b.Property<bool>("Infrastructure")
                        .HasColumnType("boolean");

                    b.Property<bool>("Security")
                        .HasColumnType("boolean");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<bool>("WaterSupply")
                        .HasColumnType("boolean");

                    b.ToTable("Garage", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.Reality");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.ToTable("LivingBuilding", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Office", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("integer");

                    b.ToTable("Office", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Production", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding");

                    b.Property<bool>("Infrastructure")
                        .HasColumnType("boolean");

                    b.Property<int>("RoomsQuantity")
                        .HasColumnType("integer");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Warehouse", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding");

                    b.Property<bool>("Infrastructure")
                        .HasColumnType("boolean");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Flat", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding");

                    b.Property<Guid?>("ApartmentHouseId")
                        .HasColumnType("uuid");

                    b.Property<string>("BalconyType")
                        .HasColumnType("text");

                    b.Property<bool>("IsFresh")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRepaired")
                        .HasColumnType("boolean");

                    b.Property<double>("KitchenArea")
                        .HasColumnType("double precision");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("integer");

                    b.Property<string>("ViewFromBalcony")
                        .HasColumnType("text");

                    b.HasIndex("ApartmentHouseId");

                    b.ToTable("Flats");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.House", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding");

                    b.Property<Guid?>("BathroomId")
                        .HasColumnType("uuid");

                    b.Property<int>("BuildYear")
                        .HasColumnType("integer");

                    b.Property<int>("FloorsCount")
                        .HasColumnType("integer");

                    b.Property<Guid?>("HouseAreaId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsAccess")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsHeating")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsInfrastructure")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLandscaping")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRenovated")
                        .HasColumnType("boolean");

                    b.Property<int>("RoomsCount")
                        .HasColumnType("integer");

                    b.HasIndex("BathroomId");

                    b.HasIndex("HouseAreaId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.HousePart", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding");

                    b.Property<Guid?>("HouseId")
                        .HasColumnType("uuid");

                    b.Property<int>("Part")
                        .HasColumnType("integer");

                    b.HasIndex("HouseId");

                    b.ToTable("HousePart", (string)null);
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Room", b =>
                {
                    b.HasBaseType("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding");

                    b.Property<Guid?>("FlatId")
                        .HasColumnType("uuid");

                    b.Property<int>("NeighboursCount")
                        .HasColumnType("integer");

                    b.HasIndex("FlatId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Announcements.Announcement", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent", "CounterAgent")
                        .WithMany()
                        .HasForeignKey("CounterAgentId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Deal", "Deal")
                        .WithMany()
                        .HasForeignKey("DealId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Reality", "Reality")
                        .WithMany()
                        .HasForeignKey("RealityId");

                    b.Navigation("CounterAgent");

                    b.Navigation("Deal");

                    b.Navigation("Reality");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Common.Elevator", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Common.ApartmentHouse", null)
                        .WithMany("Elevators")
                        .HasForeignKey("ApartmentHouseId");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.CounterAgents.Types.LegalCounterAgent", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.CounterAgents.Types.LegalCounterAgent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.CounterAgents.Types.PhysicalCounterAgent", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.CounterAgents.CounterAgent", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.CounterAgents.Types.PhysicalCounterAgent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Rent", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Deal", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Rent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction.RentConditions", "RentConditions")
                        .WithMany()
                        .HasForeignKey("RentConditionsId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Types.Rent.Addiction.RentRules", "RentRules")
                        .WithMany()
                        .HasForeignKey("RentRulesId");

                    b.Navigation("RentConditions");

                    b.Navigation("RentRules");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Deals.Types.Sell.Sell", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Deal", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Deals.Types.Sell.Sell", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomovoiBackend.Domain.Entities.Announcements.Deals.Types.Sell.Addiction.SellConditions", "SellConditions")
                        .WithMany()
                        .HasForeignKey("SellConditionsId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Deals.Types.Sell.Addiction.SellFeatures", "SellFeatures")
                        .WithMany()
                        .HasForeignKey("SellFeaturesId");

                    b.Navigation("SellConditions");

                    b.Navigation("SellFeatures");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.Areas.Area", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Reality", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.Areas.Area", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Reality", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.Garages.Garage", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Reality", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.Garages.Garage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Reality", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Office", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Office", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Production", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Production", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Warehouse", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.CommercialBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.CommercialBuildings.Types.Warehouse", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Flat", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Common.ApartmentHouse", "ApartmentHouse")
                        .WithMany()
                        .HasForeignKey("ApartmentHouseId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Flat", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApartmentHouse");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.House", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.ValueTypes.Bathroom", "Bathroom")
                        .WithMany()
                        .HasForeignKey("BathroomId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.Areas.Area", "HouseArea")
                        .WithMany()
                        .HasForeignKey("HouseAreaId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.House", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bathroom");

                    b.Navigation("HouseArea");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.HousePart", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.HousePart", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("House");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Room", b =>
                {
                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Flat", "Flat")
                        .WithMany()
                        .HasForeignKey("FlatId");

                    b.HasOne("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.LivingBuilding", null)
                        .WithOne()
                        .HasForeignKey("DomovoiBackend.Domain.Entities.Realities.LivingBuildings.Types.Room", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flat");
                });

            modelBuilder.Entity("DomovoiBackend.Domain.Entities.Common.ApartmentHouse", b =>
                {
                    b.Navigation("Elevators");
                });
#pragma warning restore 612, 618
        }
    }
}
