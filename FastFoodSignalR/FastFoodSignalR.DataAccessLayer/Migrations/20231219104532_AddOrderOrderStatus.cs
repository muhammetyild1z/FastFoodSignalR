using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodSignalR.DataAccessLayer.Migrations
{
    public partial class AddOrderOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "Orders");
        }
    }
}
