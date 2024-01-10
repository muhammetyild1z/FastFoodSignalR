using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodSignalR.DataAccessLayer.Migrations
{
    public partial class updateDiscountColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountCartColor",
                table: "Discounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BookingDesciption",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountCartColor",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "BookingDesciption",
                table: "Bookings");
        }
    }
}
