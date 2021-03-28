using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService_API.Migrations
{
    public partial class Add_Prize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Prize",
                table: "Repair",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prize",
                table: "Repair");
        }
    }
}
