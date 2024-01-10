using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FastFoodSignalR.DataAccessLayer.Migrations
{
    public partial class insertAppUserPhoneColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userPhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userPhoneNumber",
                table: "AspNetUsers");
        }
    }
}
