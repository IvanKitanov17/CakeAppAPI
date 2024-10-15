using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIncludedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncludedProduct",
                table: "IncludedProduct");

            migrationBuilder.RenameTable(
                name: "IncludedProduct",
                newName: "IncludedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_IncludedProduct_OrderId",
                table: "IncludedProducts",
                newName: "IX_IncludedProducts_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncludedProducts",
                table: "IncludedProducts",
                column: "IncludedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedProducts_Orders_OrderId",
                table: "IncludedProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncludedProducts_Orders_OrderId",
                table: "IncludedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncludedProducts",
                table: "IncludedProducts");

            migrationBuilder.RenameTable(
                name: "IncludedProducts",
                newName: "IncludedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_IncludedProducts_OrderId",
                table: "IncludedProduct",
                newName: "IX_IncludedProduct_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncludedProduct",
                table: "IncludedProduct",
                column: "IncludedProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
