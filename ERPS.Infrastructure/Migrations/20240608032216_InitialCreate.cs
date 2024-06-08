using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPS.Infrastructure.Migrations
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
                name: "mstStatus",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "mstBloodType",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstBloodType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstBloodType_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstGender",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstGender", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstGender_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstMaritalStatus",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstMaritalStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstMaritalStatus_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstNationality",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstNationality", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstNationality_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstReligion",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstReligion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstReligion_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "mstDriver",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdentityCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrivingLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    BloodTypeID = table.Column<int>(type: "int", nullable: false),
                    AddressOfIdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressOfDrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReligionID = table.Column<int>(type: "int", nullable: false),
                    MaritalStatusID = table.Column<int>(type: "int", nullable: false),
                    NationalityID = table.Column<int>(type: "int", nullable: false),
                    OccupationsIDOfIdentityCard = table.Column<int>(type: "int", nullable: false),
                    OccupationsOthersOfIdentityCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OccupationsIDOfDrivingLicense = table.Column<int>(type: "int", nullable: false),
                    OccupationsOthersOfDrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidThruOfIdentityCard = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidThruOfDrivingLicense = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DrivingLicenseTypeID = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    CreatedFromComLocID = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedFromComLocID = table.Column<int>(type: "int", nullable: false),
                    ReferencesID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogInc = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mstDriver", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstBloodType_BloodTypeID",
                        column: x => x.BloodTypeID,
                        principalSchema: "dbo",
                        principalTable: "mstBloodType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstGender_GenderID",
                        column: x => x.GenderID,
                        principalSchema: "dbo",
                        principalTable: "mstGender",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstMaritalStatus_MaritalStatusID",
                        column: x => x.MaritalStatusID,
                        principalSchema: "dbo",
                        principalTable: "mstMaritalStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstNationality_NationalityID",
                        column: x => x.NationalityID,
                        principalSchema: "dbo",
                        principalTable: "mstNationality",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstReligion_ReligionID",
                        column: x => x.ReligionID,
                        principalSchema: "dbo",
                        principalTable: "mstReligion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mstDriver_mstStatus_StatusID",
                        column: x => x.StatusID,
                        principalSchema: "dbo",
                        principalTable: "mstStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mstBloodType_StatusID",
                schema: "dbo",
                table: "mstBloodType",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_BloodTypeID",
                schema: "dbo",
                table: "mstDriver",
                column: "BloodTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_GenderID",
                schema: "dbo",
                table: "mstDriver",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_MaritalStatusID",
                schema: "dbo",
                table: "mstDriver",
                column: "MaritalStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_NationalityID",
                schema: "dbo",
                table: "mstDriver",
                column: "NationalityID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_ReligionID",
                schema: "dbo",
                table: "mstDriver",
                column: "ReligionID");

            migrationBuilder.CreateIndex(
                name: "IX_mstDriver_StatusID",
                schema: "dbo",
                table: "mstDriver",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstGender_StatusID",
                schema: "dbo",
                table: "mstGender",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstMaritalStatus_StatusID",
                schema: "dbo",
                table: "mstMaritalStatus",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstNationality_StatusID",
                schema: "dbo",
                table: "mstNationality",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_mstReligion_StatusID",
                schema: "dbo",
                table: "mstReligion",
                column: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mstDriver",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstBloodType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstGender",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstMaritalStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstNationality",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstReligion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "mstStatus",
                schema: "dbo");
        }
    }
}
