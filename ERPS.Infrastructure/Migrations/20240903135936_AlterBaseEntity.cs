using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERPS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterBaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d23b8f4f-2afc-4ba1-848d-d0dc9e94f3a6");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09e8844-6e7c-4965-9175-e58c4c836280");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstStatus",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstReligion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstReligion",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstReligion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstReligion",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstNationality",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstNationality",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstNationality",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstNationality",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstMaritalStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstMaritalStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstMaritalStatus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstMaritalStatus",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstGender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstGender",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstGender",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstGender",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstDriver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstDriver",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstDriver",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstDriver",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstBloodType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstBloodType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstBloodType",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                schema: "dbo",
                table: "mstBloodType",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8712584d-9044-4764-88c9-25163e01fe5f", null, "User", "USER" },
                    { "eaccb697-664e-48e7-99e1-3638006bb34b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8712584d-9044-4764-88c9-25163e01fe5f");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaccb697-664e-48e7-99e1-3638006bb34b");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstStatus");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstStatus");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstReligion");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstReligion");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstReligion");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstReligion");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstNationality");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstNationality");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstNationality");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstNationality");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstMaritalStatus");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstMaritalStatus");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstMaritalStatus");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstMaritalStatus");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstGender");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstGender");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstGender");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstGender");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstDriver");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstDriver");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstDriver");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstDriver");

            migrationBuilder.DropColumn(
                name: "CreatedDateUtc",
                schema: "dbo",
                table: "mstBloodType");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                schema: "dbo",
                table: "mstBloodType");

            migrationBuilder.DropColumn(
                name: "LogDateUtc",
                schema: "dbo",
                table: "mstBloodType");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                schema: "dbo",
                table: "mstBloodType");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d23b8f4f-2afc-4ba1-848d-d0dc9e94f3a6", null, "Admin", "ADMIN" },
                    { "f09e8844-6e7c-4965-9175-e58c4c836280", null, "User", "USER" }
                });
        }
    }
}
