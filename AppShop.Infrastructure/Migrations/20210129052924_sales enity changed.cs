using Microsoft.EntityFrameworkCore.Migrations;

namespace AppShop.Infrastructure.Migrations
{
    public partial class salesenitychanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickUpDetails",
                table: "Sales",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickUpDetails",
                table: "Sales");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Sales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
