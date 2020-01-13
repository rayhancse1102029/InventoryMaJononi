using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryMaJononi.Migrations
{
    public partial class version_two_barnch_name_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "branchName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "branchName",
                table: "AspNetUsers");
        }
    }
}
