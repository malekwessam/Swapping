using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoqaydaGP.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(250)", maxLength: 100, nullable: false),
                    IsAcTive = table.Column<bool>(nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryBgColor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    firstName = table.Column<string>(nullable: false),
                    lastName = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    phoneNumber = table.Column<string>(nullable: false),
                    country = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    address = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrivateItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PrivateItemeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PrivateItemDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 8000, nullable: true),
                    AvailableSince = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 200, nullable: true),
                    NumberOfQuantity = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Modifiedby = table.Column<string>(maxLength: 200, nullable: true),
                    CategoryId = table.Column<short>(nullable: true),
                    PathImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductBgColor = table.Column<int>(nullable: true),
                    IsWishlistItem = table.Column<bool>(nullable: false),
                    ProductToSwap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isfavourite = table.Column<bool>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductOwner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductOwner_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOwner_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishlistItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishlistItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishlistItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WishlistItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarteredPrivateItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PrivateItemId = table.Column<int>(nullable: true),
                    ProductOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarteredPrivateItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarteredPrivateItem_PrivateItem_PrivateItemId",
                        column: x => x.PrivateItemId,
                        principalTable: "PrivateItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarteredPrivateItem_ProductOwner_ProductOwnerId",
                        column: x => x.ProductOwnerId,
                        principalTable: "ProductOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarteredPrivateItem_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarteredProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    ProductOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarteredProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarteredProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarteredProduct_ProductOwner_ProductOwnerId",
                        column: x => x.ProductOwnerId,
                        principalTable: "ProductOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarteredProduct_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrivateSwap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    PrivateItemId = table.Column<int>(nullable: true),
                    ProductOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateSwap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateSwap_PrivateItem_PrivateItemId",
                        column: x => x.PrivateItemId,
                        principalTable: "PrivateItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateSwap_ProductOwner_ProductOwnerId",
                        column: x => x.ProductOwnerId,
                        principalTable: "ProductOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PrivateSwap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProdToSwap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    ProductOwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdToSwap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdToSwap_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdToSwap_ProductOwner_ProductOwnerId",
                        column: x => x.ProductOwnerId,
                        principalTable: "ProductOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProdToSwap_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPrivateItem_PrivateItemId",
                table: "BarteredPrivateItem",
                column: "PrivateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPrivateItem_ProductOwnerId",
                table: "BarteredPrivateItem",
                column: "ProductOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredPrivateItem_UserId",
                table: "BarteredPrivateItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredProduct_ProductId",
                table: "BarteredProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredProduct_ProductOwnerId",
                table: "BarteredProduct",
                column: "ProductOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BarteredProduct_UserId",
                table: "BarteredProduct",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateItem_UserId",
                table: "PrivateItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSwap_PrivateItemId",
                table: "PrivateSwap",
                column: "PrivateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSwap_ProductOwnerId",
                table: "PrivateSwap",
                column: "ProductOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateSwap_UserId",
                table: "PrivateSwap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdToSwap_ProductId",
                table: "ProdToSwap",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdToSwap_ProductOwnerId",
                table: "ProdToSwap",
                column: "ProductOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdToSwap_UserId",
                table: "ProdToSwap",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UserId",
                table: "Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwner_ProductId",
                table: "ProductOwner",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOwner_UserId",
                table: "ProductOwner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_ProductId",
                table: "WishlistItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WishlistItem_UserId",
                table: "WishlistItem",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarteredPrivateItem");

            migrationBuilder.DropTable(
                name: "BarteredProduct");

            migrationBuilder.DropTable(
                name: "PrivateSwap");

            migrationBuilder.DropTable(
                name: "ProdToSwap");

            migrationBuilder.DropTable(
                name: "WishlistItem");

            migrationBuilder.DropTable(
                name: "PrivateItem");

            migrationBuilder.DropTable(
                name: "ProductOwner");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
