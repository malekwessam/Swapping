using Microsoft.EntityFrameworkCore.Migrations;

namespace MoqaydaGP.Migrations
{
    public partial class xxxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrivateItemOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PrivateItemId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateItemOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateItemOwner_PrivateItem_PrivateItemId",
                        column: x => x.PrivateItemId,
                        principalTable: "PrivateItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateItemOwner_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarteredPriv",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    PrivateItemOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarteredPriv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarteredPriv_PrivateItemOwner_PrivateItemOwnerId",
                        column: x => x.PrivateItemOwnerId,
                        principalTable: "PrivateItemOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarteredPriv_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarteredPriv_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrivToSwap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    PrivateItemOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivToSwap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivToSwap_PrivateItemOwner_PrivateItemOwnerId",
                        column: x => x.PrivateItemOwnerId,
                        principalTable: "PrivateItemOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivToSwap_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivToSwap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPriv_PrivateItemOwnerId",
                table: "BarteredPriv",
                column: "PrivateItemOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPriv_ProductId",
                table: "BarteredPriv",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPriv_UserId",
                table: "BarteredPriv",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateItemOwner_PrivateItemId",
                table: "PrivateItemOwner",
                column: "PrivateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateItemOwner_UserId",
                table: "PrivateItemOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivToSwap_PrivateItemOwnerId",
                table: "PrivToSwap",
                column: "PrivateItemOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivToSwap_ProductId",
                table: "PrivToSwap",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivToSwap_UserId",
                table: "PrivToSwap",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarteredPriv");

            migrationBuilder.DropTable(
                name: "PrivToSwap");

            migrationBuilder.DropTable(
                name: "PrivateItemOwner");
        }
    }
}
