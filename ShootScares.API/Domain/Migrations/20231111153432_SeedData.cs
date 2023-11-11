using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShootScares.API.Domain.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "test" });

            migrationBuilder.InsertData(
                table: "GameResults",
                columns: new[] { "Id", "Date", "PlayerId", "Score" },
                values: new object[] { 1, new DateTime(2023, 11, 11, 17, 34, 32, 90, DateTimeKind.Local).AddTicks(3670), 1, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameResults",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
