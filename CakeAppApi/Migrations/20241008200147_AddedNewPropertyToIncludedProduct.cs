using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertyToIncludedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "IncludedProduct",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "IncludedProduct",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_IncludedProduct_Orders_OrderId",
                table: "IncludedProduct",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");
        }
    }
}
