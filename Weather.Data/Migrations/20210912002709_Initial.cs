using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Weather.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentTemperature = table.Column<int>(type: "int", nullable: false),
                    CityId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherCondition_City_CityId1",
                        column: x => x.CityId1,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Temperature = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    WeatherConditionId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WeatherConditionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureLog_WeatherCondition_WeatherConditionId1",
                        column: x => x.WeatherConditionId1,
                        principalTable: "WeatherCondition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c3857787-ddec-4d24-baf7-eaa8bfe061ab"), "Kharkov" },
                    { new Guid("c0b2002c-ab51-4297-ba65-804ec71d0768"), "Odessa" },
                    { new Guid("0afc04ce-8836-4bbd-82bd-ac2ed9bcfac0"), "Kiev" }
                });

            migrationBuilder.InsertData(
                table: "TemperatureLog",
                columns: new[] { "Id", "DateTime", "IsArchived", "Temperature", "WeatherConditionId", "WeatherConditionId1" },
                values: new object[,]
                {
                    { new Guid("6c984764-ef08-4aab-a21a-004a1ace4beb"), new DateTime(2021, 7, 20, 18, 30, 0, 0, DateTimeKind.Unspecified), false, 12, "7af24cc9-7a5d-44ad-a803-ba3ce92cb9a2", null },
                    { new Guid("eb056eab-31b4-47cf-bde3-9ed450233b0d"), new DateTime(2021, 8, 19, 19, 30, 0, 0, DateTimeKind.Unspecified), false, 15, "7af24cc9-7a5d-44ad-a803-ba3ce92cb9a2", null },
                    { new Guid("de27e207-ca73-4b7c-ab1a-80279e9af514"), new DateTime(2021, 6, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), false, 11, "35d57656-2c3d-4f32-9030-4681d45bd298", null },
                    { new Guid("b1a822a4-9180-4a1e-891e-33d9d8eae572"), new DateTime(2021, 9, 6, 18, 10, 0, 0, DateTimeKind.Unspecified), false, 14, "35d57656-2c3d-4f32-9030-4681d45bd298", null },
                    { new Guid("03c5ddf2-f492-40b9-96b5-4beefc7386ed"), new DateTime(2021, 5, 10, 12, 30, 0, 0, DateTimeKind.Unspecified), false, 17, "916a542e-36fe-4dde-ac1b-c8fe99729b40", null },
                    { new Guid("339d3a0e-e47c-4cc1-af67-d2836503dbfc"), new DateTime(2021, 4, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), false, 10, "916a542e-36fe-4dde-ac1b-c8fe99729b40", null }
                });

            migrationBuilder.InsertData(
                table: "WeatherCondition",
                columns: new[] { "Id", "CityId", "CityId1", "CurrentTemperature" },
                values: new object[,]
                {
                    { new Guid("7af24cc9-7a5d-44ad-a803-ba3ce92cb9a2"), "c3857787-ddec-4d24-baf7-eaa8bfe061ab", null, 13 },
                    { new Guid("35d57656-2c3d-4f32-9030-4681d45bd298"), "c0b2002c-ab51-4297-ba65-804ec71d0768", null, 12 },
                    { new Guid("916a542e-36fe-4dde-ac1b-c8fe99729b40"), "0afc04ce-8836-4bbd-82bd-ac2ed9bcfac0", null, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureLog_WeatherConditionId1",
                table: "TemperatureLog",
                column: "WeatherConditionId1");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCondition_CityId1",
                table: "WeatherCondition",
                column: "CityId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureLog");

            migrationBuilder.DropTable(
                name: "WeatherCondition");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
