using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dv_trading_api.Migrations
{
    /// <inheritdoc />
    public partial class UnseedTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CustomerId", "Date", "Expenses", "MeterKgs", "Moisture", "NetResecada", "NetWeight", "NoOfSacks", "PricePerKg", "SupplierId", "Type" },
                values: new object[,]
                {
                    { 1, 27995m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 70m, 7m, 927m, 1001m, 24m, 30.2m, 1, 0 },
                    { 2, 25066m, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 67m, 7.5m, 830m, 900m, 21m, 30.2m, 2, 0 },
                    { 3, 194807m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m, 246m, 4m, 5904m, 6150m, 149m, 33m, null, 1 }
                });
        }
    }
}
