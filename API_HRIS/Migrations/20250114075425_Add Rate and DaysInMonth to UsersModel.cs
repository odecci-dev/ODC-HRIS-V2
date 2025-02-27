using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class AddRateandDaysInMonthtoUsersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DaysInMonth",
                table: "tbl_UsersModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rate",
                table: "tbl_UsersModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysInMonth",
                table: "tbl_UsersModel");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "tbl_UsersModel");
        }
    }
}
