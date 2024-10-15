using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CakeAppApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewPropertyToCustomCake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomCakes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomCakes");
        }
    }
}
