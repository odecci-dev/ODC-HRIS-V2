using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_HRIS.Migrations
{
    public partial class updateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "tbl_TimeLogs",
                newName: "DeleteFlag");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "tbl_TimeLogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "tbl_TimeLogs");

            migrationBuilder.RenameColumn(
                name: "DeleteFlag",
                table: "tbl_TimeLogs",
                newName: "Status");
        }
    }
}
