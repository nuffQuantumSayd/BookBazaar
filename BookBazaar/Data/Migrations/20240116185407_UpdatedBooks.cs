using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookBazaar.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Books",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId1 = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartCartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_CartItem_Books_BookId1",
                        column: x => x.BookId1,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_ShoppingCarts_ShoppingCartCartId",
                        column: x => x.ShoppingCartCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "CartId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_BookId1",
                table: "CartItem",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ShoppingCartCartId",
                table: "CartItem",
                column: "ShoppingCartCartId");
        }
    }
}
