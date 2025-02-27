using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class UpdateDepartmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "tbl_DeparmentModel",
                newName: "DepartmentHead");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tbl_DeparmentModel",
                newName: "DeleteFlag");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "tbl_PositionModel",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentHead",
                table: "tbl_DeparmentModel",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "DeleteFlag",
                table: "tbl_DeparmentModel",
                newName: "Status");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "tbl_PositionModel",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
