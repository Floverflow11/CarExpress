using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpress.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mazda" },
                    { 2, "Jeep" },
                    { 3, "Renault" },
                    { 4, "Ford" },
                    { 5, "Honda" },
                    { 6, "Volkswagen" }
                });

            migrationBuilder.InsertData(
                table: "RepairData",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Restauration complète" },
                    { 2, "Roulements des roues avant" },
                    { 3, "Radiateur" },
                    { 4, "Freins" },
                    { 5, "Pneus" },
                    { 6, "Climatisation" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Miata" },
                    { 2, 2, "Liberty" },
                    { 3, 3, "Scénic" },
                    { 4, 4, "Explorer" },
                    { 5, 5, "Civic" },
                    { 6, 6, "GTI" },
                    { 7, 4, "Edge" }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "RepairDataId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Trims",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "LE" },
                    { 2, 2, "Sport" },
                    { 3, 3, "TCe" },
                    { 4, 4, "XLT" },
                    { 5, 5, "LX" },
                    { 6, 6, "S" },
                    { 7, 7, "SEL" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BoughtDate", "BoughtPrice", "CanBeSoldFromDate", "Description", "IsAvailable", "IsSold", "RepairCost", "TrimId", "Vin", "Year" },
                values: new object[,]
                {
                    { 1, new DateOnly(2022, 1, 7), 1800m, new DateOnly(2022, 4, 7), null, true, false, 7600m, 1, null, 2019 },
                    { 2, new DateOnly(2022, 4, 2), 4500m, new DateOnly(2022, 4, 7), null, true, false, 350m, 2, null, 2007 },
                    { 3, new DateOnly(2022, 4, 4), 1800m, new DateOnly(2022, 4, 8), null, true, false, 690m, 3, null, 2007 }
                });

            migrationBuilder.InsertData(
                table: "CarRepair",
                columns: new[] { "CarId", "RepairId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarRepair",
                keyColumns: new[] { "CarId", "RepairId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarRepair",
                keyColumns: new[] { "CarId", "RepairId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CarRepair",
                keyColumns: new[] { "CarId", "RepairId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CarRepair",
                keyColumns: new[] { "CarId", "RepairId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RepairData",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
