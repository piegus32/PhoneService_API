using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService_API.Migrations
{
    public partial class PrizeToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prize",
                table: "Repair");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Repair",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Repair");

            migrationBuilder.AddColumn<int>(
                name: "Prize",
                table: "Repair",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
