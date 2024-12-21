using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoMVC.Migrations
{
    /// <inheritdoc />
    public partial class additemspecs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemSpecs_itemId",
                table: "ItemSpecs");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecs_itemId",
                table: "ItemSpecs",
                column: "itemId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemSpecs_itemId",
                table: "ItemSpecs");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSpecs_itemId",
                table: "ItemSpecs",
                column: "itemId");
        }
    }
}
