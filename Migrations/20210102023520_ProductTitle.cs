using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoePortal_ECommerce.Migrations
{
    public partial class ProductTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShoeTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeTitle",
                table: "Products");
        }
    }
}
