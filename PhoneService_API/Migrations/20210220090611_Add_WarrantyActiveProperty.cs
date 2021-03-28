using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService_API.Migrations
{
    public partial class Add_WarrantyActiveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "WarrantyIsActive",
                table: "Repair",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WarrantyIsActive",
                table: "Repair");
        }
    }
}
