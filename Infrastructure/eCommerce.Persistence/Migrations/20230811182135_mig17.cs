using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingProduct",
                table: "ShippingProduct");

            migrationBuilder.DropIndex(
                name: "IX_ShippingProduct_ProductId_ShippingId",
                table: "ShippingProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.DropIndex(
                name: "IX_LikedProduct_ProductId_UserId",
                table: "LikedProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingProduct",
                table: "ShippingProduct",
                columns: new[] { "ProductId", "ShippingId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                columns: new[] { "ProductId", "UserId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingProduct",
                table: "ShippingProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingProduct",
                table: "ShippingProduct",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingProduct_ProductId_ShippingId",
                table: "ShippingProduct",
                columns: new[] { "ProductId", "ShippingId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LikedProduct_ProductId_UserId",
                table: "LikedProduct",
                columns: new[] { "ProductId", "UserId" },
                unique: true);
        }
    }
}
