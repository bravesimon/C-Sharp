using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MechanicService.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Country = table.Column<string>(type: "text", nullable: false),
                    County = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    Road = table.Column<string>(type: "text", nullable: false),
                    HouseNumber = table.Column<int>(type: "integer", nullable: false),
                    Information = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstMidName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    AddressId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoughtTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsWarrantyActive = table.Column<bool>(type: "boolean", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ClientID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDone = table.Column<bool>(type: "boolean", nullable: false),
                    Information = table.Column<string>(type: "text", nullable: true),
                    VehicleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "County", "HouseNumber", "Information", "PostalCode", "Road" },
                values: new object[,]
                {
                    { 1, "Gyal", "Hungary", "Pest megye", 3, "", "2360", "Bela utca" },
                    { 2, "Nyiregyhaza", "Hungary", "Szabolcs-Szatmár-Bereg megye", 42, "B haz saroknal", "4400", "Kossuth utca" },
                    { 3, "Kecskemét ", "Hungary", "Bács-Kiskun megye", 2, "", "6000", "Kövérszőlő utca" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressId", "Email", "FirstMidName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "asd@temp.com", "Akos", "Budai", "+36201234567" },
                    { 2, 2, "asd2@temp.com", "Bela", "Szervat", "+36301234567" },
                    { 3, 3, "asd3@temp.com", "Ferenc", "Kiss", "+36701234567" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BoughtTime", "ClientID", "IsWarrantyActive", "Type" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1 },
                    { 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 3 },
                    { 3, new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Date", "Information", "IsDone", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2003, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1 },
                    { 2, new DateTime(2004, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1 },
                    { 3, new DateTime(2004, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 1 },
                    { 4, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, 2 },
                    { 5, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "fek allitas lesz", false, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleId",
                table: "Services",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ClientID",
                table: "Vehicles",
                column: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
