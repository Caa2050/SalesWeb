using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedingSalesRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SalesRecord",
                columns: new[] { "Id", "Amount", "Date", "SellerId", "Status" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTime(2018, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 0.0, new DateTime(2018, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 3, 0.0, new DateTime(2018, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 4, 0.0, new DateTime(2019, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
