using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPS.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstAccess",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstAccess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstBusinessPartner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PIC = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NPWP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstBusinessPartner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstCompany",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstItemType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstModule",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstProgram",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstProgram", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstToken",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TokenType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mstUom",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstUom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstRoleProgram",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProgramId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRoleProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mstRoleProgram_mstProgram_ProgramId",
                        column: x => x.ProgramId,
                        principalSchema: "dbo",
                        principalTable: "mstProgram",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mstRoleProgram_mstRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "mstRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "mstItem",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UomId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ItemTypeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mstItem_mstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mstCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mstItem_mstItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalSchema: "dbo",
                        principalTable: "mstItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mstItem_mstUom_UomId",
                        column: x => x.UomId,
                        principalSchema: "dbo",
                        principalTable: "mstUom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstRoleCompany",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleProgramId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRoleCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mstRoleCompany_mstCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "mstCompany",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mstRoleCompany_mstRoleProgram_RoleProgramId",
                        column: x => x.RoleProgramId,
                        principalSchema: "dbo",
                        principalTable: "mstRoleProgram",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RoleProgramId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_mstRoleProgram_RoleProgramId",
                        column: x => x.RoleProgramId,
                        principalSchema: "dbo",
                        principalTable: "mstRoleProgram",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "mstRoleModule",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleCompanyId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModuleId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRoleModule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mstRoleModule_mstModule_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "dbo",
                        principalTable: "mstModule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mstRoleModule_mstRoleCompany_RoleCompanyId",
                        column: x => x.RoleCompanyId,
                        principalSchema: "dbo",
                        principalTable: "mstRoleCompany",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "mstRoleAccess",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RoleModuleId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AccessId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LogBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LogByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedByUserDisplayName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDateUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Disabled = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstRoleAccess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mstRoleAccess_mstAccess_AccessId",
                        column: x => x.AccessId,
                        principalSchema: "dbo",
                        principalTable: "mstAccess",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mstRoleAccess_mstRoleModule_RoleModuleId",
                        column: x => x.RoleModuleId,
                        principalSchema: "dbo",
                        principalTable: "mstRoleModule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_mstRoleAccess_mstRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "mstRole",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "dbo",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "dbo",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "dbo",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "dbo",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_mstItem_CompanyId",
                schema: "dbo",
                table: "mstItem",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mstItem_ItemTypeId",
                schema: "dbo",
                table: "mstItem",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_mstItem_UomId",
                schema: "dbo",
                table: "mstItem",
                column: "UomId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleAccess_AccessId",
                schema: "dbo",
                table: "mstRoleAccess",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleAccess_RoleId",
                schema: "dbo",
                table: "mstRoleAccess",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleAccess_RoleModuleId",
                schema: "dbo",
                table: "mstRoleAccess",
                column: "RoleModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleCompany_CompanyId",
                schema: "dbo",
                table: "mstRoleCompany",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleCompany_RoleProgramId",
                schema: "dbo",
                table: "mstRoleCompany",
                column: "RoleProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleModule_ModuleId",
                schema: "dbo",
                table: "mstRoleModule",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleModule_RoleCompanyId",
                schema: "dbo",
                table: "mstRoleModule",
                column: "RoleCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleProgram_ProgramId",
                schema: "dbo",
                table: "mstRoleProgram",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_mstRoleProgram_RoleId",
                schema: "dbo",
                table: "mstRoleProgram",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleProgramId",
                schema: "dbo",
                table: "UserRole",
                column: "RoleProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                schema: "dbo",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstBusinessPartner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstRoleAccess",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstToken",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstItemType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstUom",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstAccess",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstRoleModule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstModule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstRoleCompany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstCompany",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstRoleProgram",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstProgram",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstRole",
                schema: "dbo");
        }
    }
}
