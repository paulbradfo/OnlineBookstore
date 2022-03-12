using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Migrations
{
    public partial class AddOrdersField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OrderPlaced",
                table: "Cust",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPlaced",
                table: "Cust");
        }
    }
}
