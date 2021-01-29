using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppShop.Infrastructure.Migrations
{
    public partial class salesenitychanged1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpDetails",
                table: "Sales");

            migrationBuilder.AddColumn<DateTime>(
                name: "PickUpDate",
                table: "Sales",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpDate",
                table: "Sales");

            migrationBuilder.AddColumn<string>(
                name: "PickUpDetails",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
