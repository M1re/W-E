using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class wishlistmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishLists_WishListId",
                table: "WishListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists");

            migrationBuilder.RenameTable(
                name: "WishLists",
                newName: "WishListModels");

            migrationBuilder.RenameIndex(
                name: "IX_WishLists_UserId",
                table: "WishListModels",
                newName: "IX_WishListModels_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListModels",
                table: "WishListModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishListModels_WishListId",
                table: "WishListItems",
                column: "WishListId",
                principalTable: "WishListModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishListModels_AspNetUsers_UserId",
                table: "WishListModels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListItems_WishListModels_WishListId",
                table: "WishListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WishListModels_AspNetUsers_UserId",
                table: "WishListModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListModels",
                table: "WishListModels");

            migrationBuilder.RenameTable(
                name: "WishListModels",
                newName: "WishLists");

            migrationBuilder.RenameIndex(
                name: "IX_WishListModels_UserId",
                table: "WishLists",
                newName: "IX_WishLists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishLists",
                table: "WishLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListItems_WishLists_WishListId",
                table: "WishListItems",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_AspNetUsers_UserId",
                table: "WishLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
