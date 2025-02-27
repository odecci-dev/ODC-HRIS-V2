using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class Addtimelognotificationandstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "tbl_TimeLogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_TimeLogNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TimeLogNotification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TimeLogStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TimeLogStatus", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_TimeLogNotification");

            migrationBuilder.DropTable(
                name: "tbl_TimeLogStatus");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "tbl_TimeLogs");
        }
    }
}
