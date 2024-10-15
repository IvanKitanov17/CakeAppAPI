using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingtheOrderDTOandCustomCakeDTOtohave1tomanyrel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomCakeId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "CustomCakes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CustomCakes_OrderId",
                table: "CustomCakes",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomCakes_Orders_OrderId",
                table: "CustomCakes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomCakes_Orders_OrderId",
                table: "CustomCakes");

            migrationBuilder.DropIndex(
                name: "IX_CustomCakes_OrderId",
                table: "CustomCakes");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CustomCakes");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomCakeId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
