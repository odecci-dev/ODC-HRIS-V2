using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class UserModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "tbl_UsersModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionLevelId",
                table: "tbl_UsersModel",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "tbl_UsersModel");

            migrationBuilder.DropColumn(
                name: "PositionLevelId",
                table: "tbl_UsersModel");
        }
    }
}
