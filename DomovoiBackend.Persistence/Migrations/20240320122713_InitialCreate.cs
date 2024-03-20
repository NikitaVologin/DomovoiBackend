using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomovoiBackend.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApartmentHouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildingYear = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    CeilingHeight = table.Column<double>(type: "double precision", nullable: false),
                    IsGas = table.Column<bool>(type: "boolean", nullable: false),
                    HaveGarbageChute = table.Column<bool>(type: "boolean", nullable: false),
                    IsSecurity = table.Column<bool>(type: "boolean", nullable: false),
                    HaveParking = table.Column<bool>(type: "boolean", nullable: false),
                    IsInfrastructure = table.Column<bool>(type: "boolean", nullable: false),
                    IsLandscaping = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bathrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bathrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Class = table.Column<string>(type: "text", nullable: true),
                    BuildingYear = table.Column<int>(type: "integer", nullable: false),
                    CenterName = table.Column<string>(type: "text", nullable: true),
                    HaveParking = table.Column<bool>(type: "boolean", nullable: false),
                    IsEquipment = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CounterAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CounterAgents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Area = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Period = table.Column<string>(type: "text", nullable: true),
                    Deposit = table.Column<double>(type: "double precision", nullable: false),
                    CommunalPays = table.Column<double>(type: "double precision", nullable: false),
                    Prepay = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RentRules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Facilities = table.Column<string>(type: "text", nullable: true),
                    WithKids = table.Column<bool>(type: "boolean", nullable: false),
                    WithAnimals = table.Column<bool>(type: "boolean", nullable: false),
                    CanSmoke = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    YearInOwn = table.Column<int>(type: "integer", nullable: false),
                    OwnersCount = table.Column<int>(type: "integer", nullable: false),
                    PrescribersCount = table.Column<int>(type: "integer", nullable: false),
                    HaveChildOwners = table.Column<bool>(type: "boolean", nullable: false),
                    HaveChildPrescribers = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elevators",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ApartmentHouseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elevators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elevators_ApartmentHouses_ApartmentHouseId",
                        column: x => x.ApartmentHouseId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalCounterAgent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Tin = table.Column<string>(type: "text", nullable: true),
                    Trc = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCounterAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalCounterAgent_CounterAgents_Id",
                        column: x => x.Id,
                        principalTable: "CounterAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalCounterAgent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FIO = table.Column<string>(type: "text", nullable: true),
                    PassportData = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalCounterAgent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhysicalCounterAgent_CounterAgents_Id",
                        column: x => x.Id,
                        principalTable: "CounterAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ConnectionType = table.Column<string>(type: "text", nullable: true),
                    RealityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DealId = table.Column<Guid>(type: "uuid", nullable: true),
                    CounterAgentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_CounterAgents_CounterAgentId",
                        column: x => x.CounterAgentId,
                        principalTable: "CounterAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Announcements_Reality_RealityId",
                        column: x => x.RealityId,
                        principalTable: "Reality",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Electricity = table.Column<bool>(type: "boolean", nullable: false),
                    WaterSupply = table.Column<bool>(type: "boolean", nullable: false),
                    Gas = table.Column<bool>(type: "boolean", nullable: false),
                    Sewage = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_Reality_Id",
                        column: x => x.Id,
                        principalTable: "Reality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommercialBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FloorsCount = table.Column<int>(type: "integer", nullable: false),
                    Entry = table.Column<bool>(type: "boolean", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IsUse = table.Column<bool>(type: "boolean", nullable: false),
                    IsAccess = table.Column<bool>(type: "boolean", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommercialBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommercialBuildings_Reality_Id",
                        column: x => x.Id,
                        principalTable: "Reality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    GKSName = table.Column<string>(type: "text", nullable: true),
                    Access = table.Column<bool>(type: "boolean", nullable: false),
                    Security = table.Column<bool>(type: "boolean", nullable: false),
                    Electricity = table.Column<bool>(type: "boolean", nullable: false),
                    Heating = table.Column<bool>(type: "boolean", nullable: false),
                    WaterSupply = table.Column<bool>(type: "boolean", nullable: false),
                    Infrastructure = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garage_Reality_Id",
                        column: x => x.Id,
                        principalTable: "Reality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivingBuilding",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivingBuilding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivingBuilding_Reality_Id",
                        column: x => x.Id,
                        principalTable: "Reality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentConditionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    RentRulesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_Deals_Id",
                        column: x => x.Id,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_RentConditions_RentConditionsId",
                        column: x => x.RentConditionsId,
                        principalTable: "RentConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rent_RentRules_RentRulesId",
                        column: x => x.RentRulesId,
                        principalTable: "RentRules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SellConditionsId = table.Column<Guid>(type: "uuid", nullable: true),
                    SellFeaturesId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sell_Deals_Id",
                        column: x => x.Id,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sell_SellConditions_SellConditionsId",
                        column: x => x.SellConditionsId,
                        principalTable: "SellConditions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sell_SellFeatures_SellFeaturesId",
                        column: x => x.SellFeaturesId,
                        principalTable: "SellFeatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RoomsCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Office_CommercialBuildings_Id",
                        column: x => x.Id,
                        principalTable: "CommercialBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Infrastructure = table.Column<bool>(type: "boolean", nullable: false),
                    RoomsQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productions_CommercialBuildings_Id",
                        column: x => x.Id,
                        principalTable: "CommercialBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Infrastructure = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_CommercialBuildings_Id",
                        column: x => x.Id,
                        principalTable: "CommercialBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsFresh = table.Column<bool>(type: "boolean", nullable: false),
                    RoomsCount = table.Column<int>(type: "integer", nullable: false),
                    IsRepaired = table.Column<bool>(type: "boolean", nullable: false),
                    KitchenArea = table.Column<double>(type: "double precision", nullable: false),
                    BalconyType = table.Column<string>(type: "text", nullable: true),
                    ViewFromBalcony = table.Column<string>(type: "text", nullable: true),
                    ApartmentHouseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_ApartmentHouses_ApartmentHouseId",
                        column: x => x.ApartmentHouseId,
                        principalTable: "ApartmentHouses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flats_LivingBuilding_Id",
                        column: x => x.Id,
                        principalTable: "LivingBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BuildYear = table.Column<int>(type: "integer", nullable: false),
                    RoomsCount = table.Column<int>(type: "integer", nullable: false),
                    FloorsCount = table.Column<int>(type: "integer", nullable: false),
                    IsRenovated = table.Column<bool>(type: "boolean", nullable: false),
                    IsHeating = table.Column<bool>(type: "boolean", nullable: false),
                    IsAccess = table.Column<bool>(type: "boolean", nullable: false),
                    IsInfrastructure = table.Column<bool>(type: "boolean", nullable: false),
                    IsLandscaping = table.Column<bool>(type: "boolean", nullable: false),
                    BathroomId = table.Column<Guid>(type: "uuid", nullable: true),
                    HouseAreaId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Area_HouseAreaId",
                        column: x => x.HouseAreaId,
                        principalTable: "Area",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Bathrooms_BathroomId",
                        column: x => x.BathroomId,
                        principalTable: "Bathrooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_LivingBuilding_Id",
                        column: x => x.Id,
                        principalTable: "LivingBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NeighboursCount = table.Column<int>(type: "integer", nullable: false),
                    FlatId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rooms_LivingBuilding_Id",
                        column: x => x.Id,
                        principalTable: "LivingBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousePart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Part = table.Column<int>(type: "integer", nullable: false),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HousePart_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HousePart_LivingBuilding_Id",
                        column: x => x.Id,
                        principalTable: "LivingBuilding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_CounterAgentId",
                table: "Announcements",
                column: "CounterAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_DealId",
                table: "Announcements",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_RealityId",
                table: "Announcements",
                column: "RealityId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Id",
                table: "Area",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bathrooms_Id",
                table: "Bathrooms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_Id",
                table: "Buildings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommercialBuildings_BuildingId",
                table: "CommercialBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CommercialBuildings_Id",
                table: "CommercialBuildings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CounterAgents_Id",
                table: "CounterAgents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deals_Id",
                table: "Deals",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Elevators_ApartmentHouseId",
                table: "Elevators",
                column: "ApartmentHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_ApartmentHouseId",
                table: "Flats",
                column: "ApartmentHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Flats_Id",
                table: "Flats",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Garage_Id",
                table: "Garage",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HousePart_HouseId",
                table: "HousePart",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HousePart_Id",
                table: "HousePart",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Houses_BathroomId",
                table: "Houses",
                column: "BathroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseAreaId",
                table: "Houses",
                column: "HouseAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_Id",
                table: "Houses",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalCounterAgent_Id",
                table: "LegalCounterAgent",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LivingBuilding_Id",
                table: "LivingBuilding",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Office_Id",
                table: "Office",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalCounterAgent_Id",
                table: "PhysicalCounterAgent",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productions_Id",
                table: "Productions",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reality_Id",
                table: "Reality",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rent_Id",
                table: "Rent",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rent_RentConditionsId",
                table: "Rent",
                column: "RentConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_RentRulesId",
                table: "Rent",
                column: "RentRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FlatId",
                table: "Rooms",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Id",
                table: "Rooms",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sell_Id",
                table: "Sell",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sell_SellConditionsId",
                table: "Sell",
                column: "SellConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sell_SellFeaturesId",
                table: "Sell",
                column: "SellFeaturesId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Id",
                table: "Warehouses",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Elevators");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "HousePart");

            migrationBuilder.DropTable(
                name: "LegalCounterAgent");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "PhysicalCounterAgent");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Sell");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "CounterAgents");

            migrationBuilder.DropTable(
                name: "RentConditions");

            migrationBuilder.DropTable(
                name: "RentRules");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "SellConditions");

            migrationBuilder.DropTable(
                name: "SellFeatures");

            migrationBuilder.DropTable(
                name: "CommercialBuildings");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Bathrooms");

            migrationBuilder.DropTable(
                name: "ApartmentHouses");

            migrationBuilder.DropTable(
                name: "LivingBuilding");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Reality");
        }
    }
}
