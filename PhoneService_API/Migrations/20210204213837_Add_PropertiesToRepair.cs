using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneService_API.Migrations
{
    public partial class Add_PropertiesToRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "Repair",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "DoneAttr",
                table: "Repair",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyDate",
                table: "Repair",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "Repair");

            migrationBuilder.DropColumn(
                name: "DoneAttr",
                table: "Repair");

            migrationBuilder.DropColumn(
                name: "WarrantyDate",
                table: "Repair");
        }
    }
}
