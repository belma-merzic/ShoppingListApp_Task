using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListApp_API.Services.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Item__727E83EBC59DB928", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Shopper",
                columns: table => new
                {
                    ShopperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopperName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopper__1291733F18E77DB8", x => x.ShopperID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingList",
                columns: table => new
                {
                    ShoppingListID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopperID = table.Column<int>(type: "int", nullable: true),
                    ItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shopping__6CBBDD7456453DC5", x => x.ShoppingListID);
                    table.ForeignKey(
                        name: "FK__ShoppingL__ItemI__3C69FB99",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK__ShoppingL__Shopp__3B75D760",
                        column: x => x.ShopperID,
                        principalTable: "Shopper",
                        principalColumn: "ShopperID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ItemID",
                table: "ShoppingList",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_ShopperID",
                table: "ShoppingList",
                column: "ShopperID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingList");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Shopper");
        }
    }
}
