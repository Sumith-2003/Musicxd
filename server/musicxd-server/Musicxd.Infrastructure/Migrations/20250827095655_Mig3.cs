using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Musicxd.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "date",
                columns: new[] { "date_id", "date_value", "day", "decade", "month", "year" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2020, 1, 2023 },
                    { 2, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 2020, 3, 2023 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "user_id", "email", "password" },
                values: new object[,]
                {
                    { 1, "john.doe@example.com", "Password123!" },
                    { 2, "jane.smith@example.com", "SecurePass456!" }
                });

            migrationBuilder.InsertData(
                table: "profile",
                columns: new[] { "profile_id", "bio", "date_joined_id", "location", "user_id", "username", "website" },
                values: new object[,]
                {
                    { 1, "Music enthusiast and vinyl collector", 1, "New York, NY", 1, "JohnDoe", "https://johndoe.com" },
                    { 2, "Passionate about discovering new artists and genres", 2, "Los Angeles, CA", 2, "JaneSmith", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "profile",
                keyColumn: "profile_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "profile",
                keyColumn: "profile_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "date",
                keyColumn: "date_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "date",
                keyColumn: "date_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "user_id",
                keyValue: 2);
        }
    }
}
