using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class UpdateNotificationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "tbl_TimeLogNotification");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "tbl_TimeLogNotification");

            migrationBuilder.DropColumn(
                name: "TimeIn",
                table: "tbl_TimeLogNotification");

            migrationBuilder.DropColumn(
                name: "TimeOut",
                table: "tbl_TimeLogNotification");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "tbl_TimeLogNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "tbl_TimeLogNotification ",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeIn",
                table: "tbl_TimeLogNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeOut",
                table: "tbl_TimeLogNotification",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
