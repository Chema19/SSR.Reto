using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Permission.Persistence.Database.Migrations
{
    public partial class Initializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Permission");

            migrationBuilder.CreateTable(
                name: "PermissionTypess",
                schema: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypess", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissionss",
                schema: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeForename = table.Column<string>(maxLength: 500, nullable: false),
                    EmployeeSurname = table.Column<string>(maxLength: 500, nullable: false),
                    PermissionType = table.Column<int>(nullable: false),
                    PermissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissionss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissionss_PermissionTypess_PermissionType",
                        column: x => x.PermissionType,
                        principalSchema: "Permission",
                        principalTable: "PermissionTypess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissionss_Id",
                schema: "Permission",
                table: "Permissionss",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissionss_PermissionType",
                schema: "Permission",
                table: "Permissionss",
                column: "PermissionType");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTypess_Id",
                schema: "Permission",
                table: "PermissionTypess",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissionss",
                schema: "Permission");

            migrationBuilder.DropTable(
                name: "PermissionTypess",
                schema: "Permission");
        }
    }
}
