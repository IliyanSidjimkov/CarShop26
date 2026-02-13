using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop26.Data.Migrations
{
    /// <inheritdoc />
    public partial class OneCarSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGo7CT9J60UZupVlsWbQ0T9jQLIsO77fUR1tGPQ5awS0Yxzs5l07GuWAXC7ey4iZ2g==");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedOn", "FuelType", "GearboxType", "ImageUrl", "Mileage", "Model", "Price", "UserId", "Year" },
                values: new object[] { 1, "Audi", 8, 1, new DateTime(2026, 2, 13, 1, 11, 28, 287, DateTimeKind.Local).AddTicks(9727), 1, 1, "https://alarmsyst-bg.com/cdn/shop/files/audi-a4-b8-8k-facelift-2009-2015-1499x843_1024x1024.jpg?v=1747237269", 120000, "A4", 15000.00m, "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 2015 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECqos+SFpqsPFjxJQ5BveUcy+wWQeG/jpinvi/bc0Lu2wyqzq52HpzUflrZMdrdkng==");
        }
    }
}
