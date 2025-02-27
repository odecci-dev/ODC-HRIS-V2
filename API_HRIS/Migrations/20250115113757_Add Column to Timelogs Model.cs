using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class AddColumntoTimelogsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "tbl_TimeLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeleted",
                table: "tbl_TimeLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "tbl_TimeLogs",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "tbl_TimeLogs");

            migrationBuilder.DropColumn(
                name: "DateDeleted",
                table: "tbl_TimeLogs");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "tbl_TimeLogs");
        }
    }
}
