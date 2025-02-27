using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class RecreateNotificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "tbl_TimeLogNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", unicode: false, nullable: true),
                    Notification = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    StatusId = table.Column<int>(type: "int", unicode: false, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TimeLogNotification", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "TblTimeLogNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogId = table.Column<int>(type: "int", nullable: true),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTimeLogNotification", x => x.Id);
                });
        }
    }
}
