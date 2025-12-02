using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearnProject.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Diffculties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4789-9012-3456789abcde"), "Easy" },
                    { new Guid("b2c3d4e5-f6a1-4890-0123-456789abcdef"), "Medium" },
                    { new Guid("c3d4e5f6-a1b2-4901-1234-56789abcdef0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("a4b5c6d7-e8f9-5041-9012-444444444444"), "OTA", "Otago", "https://example.com/images/otago.jpg" },
                    { new Guid("b5c6d7e8-f9a1-5152-9012-555555555555"), "BOP", "Bay of Plenty", "https://example.com/images/bay-of-plenty.jpg" },
                    { new Guid("d1e2f3a4-b5c6-4718-9012-111111111111"), "AKL", "Auckland", "https://example.com/images/auckland.jpg" },
                    { new Guid("e2f3a4b5-c6d7-4829-9012-222222222222"), "WLG", "Wellington", "https://example.com/images/wellington.jpg" },
                    { new Guid("f3a4b5c6-d7e8-4930-9012-333333333333"), "CAN", "Canterbury", "https://example.com/images/canterbury.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Diffculties",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4789-9012-3456789abcde"));

            migrationBuilder.DeleteData(
                table: "Diffculties",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a1-4890-0123-456789abcdef"));

            migrationBuilder.DeleteData(
                table: "Diffculties",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a1b2-4901-1234-56789abcdef0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a4b5c6d7-e8f9-5041-9012-444444444444"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b5c6d7e8-f9a1-5152-9012-555555555555"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d1e2f3a4-b5c6-4718-9012-111111111111"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e2f3a4b5-c6d7-4829-9012-222222222222"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f3a4b5c6-d7e8-4930-9012-333333333333"));
        }
    }
}
