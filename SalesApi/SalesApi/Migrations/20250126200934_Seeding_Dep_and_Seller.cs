using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesApi.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Dep_and_Seller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Computers" },
                    { 2, "Electronics" },
                    { 3, "Fashion" },
                    { 4, "Books" }
                });

            migrationBuilder.InsertData(
                table: "Seller",
                columns: new[] { "Id", "BaseSalary", "BirthDate", "DepartmentId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 3200.0, new DateTime(1998, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "bob@gmail.com", "Bob" },
                    { 2, 2000.0, new DateTime(1993, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "carl@gmail.com", "Carl" },
                    { 3, 4000.0, new DateTime(1990, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "nick@gmail.com", "Nick" },
                    { 4, 2500.0, new DateTime(2000, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "kate@gmail.com", "Kate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seller",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
