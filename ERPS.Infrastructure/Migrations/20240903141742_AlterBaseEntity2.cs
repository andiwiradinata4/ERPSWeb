using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERPS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterBaseEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "675aa40f-024f-4b91-8383-4d16e1e40e46");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bcebb6d-626b-49f9-941e-aae345dc0031");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "675aa40f-024f-4b91-8383-4d16e1e40e46", null, "User", "USER" },
                    { "9bcebb6d-626b-49f9-941e-aae345dc0031", null, "Admin", "ADMIN" }
                });
        }
    }
}
