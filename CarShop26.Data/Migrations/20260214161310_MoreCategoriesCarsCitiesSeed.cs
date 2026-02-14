using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarShop26.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreCategoriesCarsCitiesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFB74yP0mW97RIoKzcDZygvxAYN1nFtEhXLWJQcfUmzxOu1U0KXyDilsf6q6/h0y+Q==");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 2, 14, 18, 13, 10, 359, DateTimeKind.Local).AddTicks(267));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedOn", "FuelType", "GearboxType", "ImageUrl", "Mileage", "Model", "Price", "UserId", "Year" },
                values: new object[,]
                {
                    { 4, "Audi", 4, 6, new DateTime(2026, 2, 14, 18, 13, 10, 359, DateTimeKind.Local).AddTicks(316), 1, 1, "https://ahq-img.b-cdn.net/1122/v4461-13.jpg?width=1800", 185000, "A6", 14000.00m, "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 2013 },
                    { 5, "Audi", 4, 2, new DateTime(2026, 2, 14, 18, 13, 10, 359, DateTimeKind.Local).AddTicks(318), 0, 1, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSMtrUBtcK5dc8u9urUVoaWrpmd_HGtMx_OwA&s", 155000, "RS6", 90000.00m, "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 9, "Hatchback" },
                    { 10, "SUV" },
                    { 11, "Sportback" }
                });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CityName",
                value: "Stara Zagora");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CityName",
                value: "Pleven");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CityName",
                value: "Sliven");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { 9, "Dobrich" },
                    { 10, "Shumen" },
                    { 11, "Pernik" },
                    { 12, "Haskovo" },
                    { 13, "Yambol" },
                    { 14, "Pazardzhik" },
                    { 15, "Blagoevgrad" },
                    { 16, "Veliko Tarnovo" },
                    { 17, "Vratsa" },
                    { 18, "Gabrovo" },
                    { 19, "Kardzhali" },
                    { 20, "Kyustendil" },
                    { 21, "Lovech" },
                    { 22, "Montana" },
                    { 23, "Razgrad" },
                    { 24, "Silistra" },
                    { 25, "Smolyan" },
                    { 26, "Targovishte" },
                    { 27, "Vidin" },
                    { 28, "Sofia Province" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "CityId", "CreatedOn", "FuelType", "GearboxType", "ImageUrl", "Mileage", "Model", "Price", "UserId", "Year" },
                values: new object[,]
                {
                    { 2, "Audi", 9, 5, new DateTime(2026, 2, 14, 18, 13, 10, 359, DateTimeKind.Local).AddTicks(310), 1, 1, "https://cdn.images.autoexposure.co.uk/AETA31676/AETV29758780_1e.jpg", 90000, "A3", 20000.00m, "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 2020 },
                    { 3, "Audi", 11, 4, new DateTime(2026, 2, 14, 18, 13, 10, 359, DateTimeKind.Local).AddTicks(314), 0, 0, "https://f7432d8eadcf865aa9d9-9c672a3a4ecaaacdf2fee3b3e6fd2716.ssl.cf3.rackcdn.com/C3312/U574/IMG_9463-large.jpg", 150000, "A5", 18000.00m, "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 2018 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGo7CT9J60UZupVlsWbQ0T9jQLIsO77fUR1tGPQ5awS0Yxzs5l07GuWAXC7ey4iZ2g==");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 2, 13, 1, 11, 28, 287, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                column: "CityName",
                value: "Blagoevgrad");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                column: "CityName",
                value: "Veliko Tarnovo");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                column: "CityName",
                value: "Vidin");
        }
    }
}
