using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarShop26.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f", 0, "f81c19fd-26e6-4bf4-b0d5-9fe7b6ab964e", "admin@test.bg", true, false, null, "ADMIN@TEST.BG", "ADMIN@TEST.BG", "AQAAAAIAAYagAAAAECqos+SFpqsPFjxJQ5BveUcy+wWQeG/jpinvi/bc0Lu2wyqzq52HpzUflrZMdrdkng==", null, false, "YIXYIXE6GJSSN4KVYJROXMJQKQ2EVPJT", false, "admin@test.bg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 8, "Sedan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fe0f0881-a76d-4cd6-9a79-3f6adbd5f82f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
