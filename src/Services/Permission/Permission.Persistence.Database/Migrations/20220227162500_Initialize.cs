using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Permission.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Permission");

            migrationBuilder.CreateTable(
                name: "Permissionss",
                schema: "Permission",
                columns: table => new
                {
                    PermissionType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    EmployeeForename = table.Column<string>(maxLength: 500, nullable: false),
                    EmployeeSurname = table.Column<string>(maxLength: 500, nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissionss", x => x.PermissionType);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTypess",
                schema: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    PermissionsPermissionType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermissionTypess_Permissionss_PermissionsPermissionType",
                        column: x => x.PermissionsPermissionType,
                        principalSchema: "Permission",
                        principalTable: "Permissionss",
                        principalColumn: "PermissionType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissionss_Id",
                schema: "Permission",
                table: "Permissionss",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTypess_Id",
                schema: "Permission",
                table: "PermissionTypess",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTypess_PermissionsPermissionType",
                schema: "Permission",
                table: "PermissionTypess",
                column: "PermissionsPermissionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionTypess",
                schema: "Permission");

            migrationBuilder.DropTable(
                name: "Permissionss",
                schema: "Permission");
        }
    }
}
