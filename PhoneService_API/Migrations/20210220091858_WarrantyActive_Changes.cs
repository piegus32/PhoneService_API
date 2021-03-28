using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService_API.Migrations
{
    public partial class WarrantyActive_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarrantyIsActive",
                table: "Repair");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WarrantyIsActive",
                table: "Repair",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
