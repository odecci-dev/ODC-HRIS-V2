using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class PositionModelUpdateredo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionLevelId",
                table: "tbl_PositionModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionLevelId",
                table: "tbl_PositionModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
