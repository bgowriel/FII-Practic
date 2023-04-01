using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstateWebManager.DataAccess.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    County = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhonePrefix = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Continent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pollution = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Traffic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LivingCost = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Criminality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AverageTemperature = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstateAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateAgents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<int>(type: "int", nullable: true),
                    DoorNumber = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionType = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PeriodOfTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstate_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstate_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => new { x.AgentId, x.ClientId, x.RealEstateId });
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_EstateAgents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "EstateAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    BuiltUpArea = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Heating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParkingPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvailableStarting = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flats_RealEstate_Id",
                        column: x => x.Id,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    BuiltUpArea = table.Column<int>(type: "int", nullable: false),
                    LandArea = table.Column<int>(type: "int", nullable: false),
                    Floors = table.Column<int>(type: "int", nullable: false),
                    Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Heating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Garage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SwimmingPool = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvailableStarting = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_RealEstate_Id",
                        column: x => x.Id,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealEstateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_RealEstate_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LandArea = table.Column<int>(type: "int", nullable: false),
                    Topography = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fence = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Electricity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Water = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sewerage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Heating = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvailableStarting = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lands_RealEstate_Id",
                        column: x => x.Id,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BuiltUpArea = table.Column<int>(type: "int", nullable: false),
                    AC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Internet = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParkingPlace = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AvailableStarting = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offices_RealEstate_Id",
                        column: x => x.Id,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AgentId_Date",
                table: "Appointments",
                columns: new[] { "AgentId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId_Date",
                table: "Appointments",
                columns: new[] { "ClientId", "Date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RealEstateId",
                table: "Appointments",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Name",
                table: "Clients",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EstateAgents_Name",
                table: "EstateAgents",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_RealEstateId",
                table: "Images",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_AreaId",
                table: "RealEstate",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_UserId",
                table: "RealEstate",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EstateAgents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
