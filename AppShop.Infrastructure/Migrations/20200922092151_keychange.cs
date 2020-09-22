using Microsoft.EntityFrameworkCore.Migrations;

namespace AppShop.Infrastructure.Migrations
{
    public partial class keychange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderGroup",
                table: "Sales",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_OrderGroup",
                table: "Sales",
                column: "OrderGroup",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sales_OrderGroup",
                table: "Sales");

            migrationBuilder.AlterColumn<string>(
                name: "OrderGroup",
                table: "Sales",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
