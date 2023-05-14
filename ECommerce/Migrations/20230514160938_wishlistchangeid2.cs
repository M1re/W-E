using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class wishlistchangeid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishListModels_WishListId",
                table: "WishListItems");

            migrationBuilder.DropIndex(
                name: "IX_WishListItems_WishListId",
                table: "WishListItems");

            migrationBuilder.AlterColumn<string>(
                name: "WishListId",
                table: "WishListItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "WishListModelId",
                table: "WishListItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_WishListModelId",
                table: "WishListItems",
                column: "WishListModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishListModels_WishListModelId",
                table: "WishListItems",
                column: "WishListModelId",
                principalTable: "WishListModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishListModels_WishListModelId",
                table: "WishListItems");

            migrationBuilder.DropIndex(
                name: "IX_WishListItems_WishListModelId",
                table: "WishListItems");

            migrationBuilder.DropColumn(
                name: "WishListModelId",
                table: "WishListItems");

            migrationBuilder.AlterColumn<string>(
                name: "WishListId",
                table: "WishListItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_WishListItems_WishListId",
                table: "WishListItems",
                column: "WishListId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishListModels_WishListId",
                table: "WishListItems",
                column: "WishListId",
                principalTable: "WishListModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
