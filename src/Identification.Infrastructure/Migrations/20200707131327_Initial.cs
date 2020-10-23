using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hlopov.CreditBroker.Identification.Infrastructure.Migrations
{
    /// <summary>
    /// initial migration
    /// </summary>
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArmUserPhoneTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmUserPhoneTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArmUserPhones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    ArmUserId = table.Column<Guid>(nullable: false),
                    ArmUserPhoneTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmUserPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmUserPhones_ArmUserPhoneTypes_ArmUserPhoneTypeId",
                        column: x => x.ArmUserPhoneTypeId,
                        principalTable: "ArmUserPhoneTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    SuperiorDepartmentId = table.Column<Guid>(nullable: false),
                    DepartmentHeadId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_SuperiorDepartmentId",
                        column: x => x.SuperiorDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArmUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Login = table.Column<string>(maxLength: 255, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    RecoveryToken = table.Column<string>(nullable: true),
                    RecoveryTokenExpireDate = table.Column<DateTime>(nullable: true),
                    PositionId = table.Column<Guid>(nullable: true),
                    DepartmentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArmUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArmUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArmUsers_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 1024, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ArmUserId = table.Column<Guid>(nullable: false),
                    Token = table.Column<string>(maxLength: 1024, nullable: true),
                    TokenCreateDate = table.Column<DateTime>(nullable: true),
                    TokenExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDevices_ArmUsers_ArmUserId",
                        column: x => x.ArmUserId,
                        principalTable: "ArmUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArmUserPhones_ArmUserId",
                table: "ArmUserPhones",
                column: "ArmUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUserPhones_ArmUserPhoneTypeId",
                table: "ArmUserPhones",
                column: "ArmUserPhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUsers_DepartmentId",
                table: "ArmUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUsers_Login",
                table: "ArmUsers",
                column: "Login");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUsers_Name",
                table: "ArmUsers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUsers_PositionId",
                table: "ArmUsers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ArmUsers_RecoveryToken",
                table: "ArmUsers",
                column: "RecoveryToken");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_SuperiorDepartmentId",
                table: "Departments",
                column: "SuperiorDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevices_ArmUserId",
                table: "UserDevices",
                column: "ArmUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevices_Token",
                table: "UserDevices",
                column: "Token");

            migrationBuilder.AddForeignKey(
                name: "FK_ArmUserPhones_ArmUsers_ArmUserId",
                table: "ArmUserPhones",
                column: "ArmUserId",
                principalTable: "ArmUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ArmUsers_DepartmentHeadId",
                table: "Departments",
                column: "DepartmentHeadId",
                principalTable: "ArmUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ArmUsers_DepartmentHeadId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "ArmUserPhones");

            migrationBuilder.DropTable(
                name: "UserDevices");

            migrationBuilder.DropTable(
                name: "ArmUserPhoneTypes");

            migrationBuilder.DropTable(
                name: "ArmUsers");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
