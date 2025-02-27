using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class Createtableforscheduleandemploymentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_EmploymentStatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScheduleId = table.Column<int>(type: "int", nullable: true),
                    StatusID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EmploymentStatusModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ScheduleModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MondayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TuesdayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WednesdayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThursdayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FridayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaturdayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SundayE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ScheduleModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EmploymentStatusModel");

            migrationBuilder.DropTable(
                name: "tbl_ScheduleModel");
        }
    }
}
