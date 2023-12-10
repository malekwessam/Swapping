using Microsoft.EntityFrameworkCore.Migrations;

namespace MoqaydaGP.Migrations
{
    public partial class fffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarteredPrivateItem_ProductOwner_ProductOwnerId",
                table: "BarteredPrivateItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BarteredProduct_ProductOwner_ProductOwnerId",
                table: "BarteredProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateSwap_ProductOwner_ProductOwnerId",
                table: "PrivateSwap");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdToSwap_ProductOwner_ProductOwnerId",
                table: "ProdToSwap");

            migrationBuilder.AddForeignKey(
                name: "FK_BarteredPrivateItem_ProductOwner_ProductOwnerId",
                table: "BarteredPrivateItem",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarteredProduct_ProductOwner_ProductOwnerId",
                table: "BarteredProduct",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateSwap_ProductOwner_ProductOwnerId",
                table: "PrivateSwap",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdToSwap_ProductOwner_ProductOwnerId",
                table: "ProdToSwap",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarteredPrivateItem_ProductOwner_ProductOwnerId",
                table: "BarteredPrivateItem");

            migrationBuilder.DropForeignKey(
                name: "FK_BarteredProduct_ProductOwner_ProductOwnerId",
                table: "BarteredProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivateSwap_ProductOwner_ProductOwnerId",
                table: "PrivateSwap");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdToSwap_ProductOwner_ProductOwnerId",
                table: "ProdToSwap");

            migrationBuilder.AddForeignKey(
                name: "FK_BarteredPrivateItem_ProductOwner_ProductOwnerId",
                table: "BarteredPrivateItem",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BarteredProduct_ProductOwner_ProductOwnerId",
                table: "BarteredProduct",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateSwap_ProductOwner_ProductOwnerId",
                table: "PrivateSwap",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdToSwap_ProductOwner_ProductOwnerId",
                table: "ProdToSwap",
                column: "ProductOwnerId",
                principalTable: "ProductOwner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
