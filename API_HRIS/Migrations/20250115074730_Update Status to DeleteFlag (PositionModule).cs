using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class UpdateStatustoDeleteFlagPositionModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tbl_PositionModel",
                newName: "DeleteFlag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteFlag",
                table: "tbl_PositionModel",
                newName: "Status");
        }
    }
}
