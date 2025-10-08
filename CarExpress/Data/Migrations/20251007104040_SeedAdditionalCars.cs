using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarExpress.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdditionalCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BoughtDate", "BoughtPrice", "CanBeSoldFromDate", "Description", "IsAvailable", "IsSold", "RepairCost", "TrimId", "Vin", "Year" },
                values: new object[,]
                {
                    { 4, new DateOnly(2022, 4, 5), 24350m, new DateOnly(2022, 4, 9), null, true, false, 1100m, 4, null, 2017 },
                    { 5, new DateOnly(2022, 4, 6), 4000m, new DateOnly(2022, 4, 9), null, true, false, 475m, 5, null, 2008 },
                    { 6, new DateOnly(2022, 4, 6), 15250m, new DateOnly(2022, 4, 10), null, true, false, 440m, 6, null, 2016 },
                    { 7, new DateOnly(2022, 4, 7), 10990m, new DateOnly(2022, 4, 11), null, true, false, 950m, 7, null, 2013 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
