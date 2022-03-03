using Microsoft.EntityFrameworkCore.Migrations;

namespace book.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Books",
            //    columns: table => new
            //    {
            //        BookId = table.Column<int>(nullable: false)
            //            .Annotation("Sqlite:Autoincrement", true),
            //        Title = table.Column<string>(nullable: true),
            //        Author = table.Column<string>(nullable: true),
            //        Publisher = table.Column<string>(nullable: true),
            //        Isbn = table.Column<string>(nullable: true),
            //        Classification = table.Column<string>(nullable: true),
            //        Category = table.Column<string>(nullable: true),
            //        PageCount = table.Column<int>(nullable: false),
            //        Price = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Books", x => x.BookId);
            //    });

            migrationBuilder.CreateTable(
                name: "Cust",
                columns: table => new
                {
                    CustId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: false),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zipcode = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cust", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "CartLineItem",
                columns: table => new
                {
                    LineID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    CustInfoCustId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLineItem", x => x.LineID);
                    table.ForeignKey(
                        name: "FK_CartLineItem_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartLineItem_Cust_CustInfoCustId",
                        column: x => x.CustInfoCustId,
                        principalTable: "Cust",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_BookId",
                table: "CartLineItem",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLineItem_CustInfoCustId",
                table: "CartLineItem",
                column: "CustInfoCustId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLineItem");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Cust");
        }
    }
}
