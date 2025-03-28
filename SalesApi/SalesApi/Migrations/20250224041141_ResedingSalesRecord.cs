using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesApi.Migrations
{
    /// <inheritdoc />
    public partial class ResedingSalesRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 400.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 500.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 2,
                column: "Amount",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 3,
                column: "Amount",
                value: 0.0);

            migrationBuilder.UpdateData(
                table: "SalesRecord",
                keyColumn: "Id",
                keyValue: 4,
                column: "Amount",
                value: 0.0);
        }
    }
}
