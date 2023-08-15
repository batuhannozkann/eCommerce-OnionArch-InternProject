using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_Addresses_AddressId",
                table: "Shipping");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_AspNetUsers_UserId",
                table: "Shipping");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_Orders_OrderId",
                table: "Shipping");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipping_ShippingCompany_ShippingCompanyId",
                table: "Shipping");

            migrationBuilder.DropForeignKey(
                name: "FK_ShippingProduct_Shipping_ShippingId",
                table: "ShippingProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingCompany",
                table: "ShippingCompany");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipping",
                table: "Shipping");

            migrationBuilder.RenameTable(
                name: "ShippingCompany",
                newName: "ShippingCompanies");

            migrationBuilder.RenameTable(
                name: "Shipping",
                newName: "Shippings");

            migrationBuilder.RenameIndex(
                name: "IX_Shipping_UserId",
                table: "Shippings",
                newName: "IX_Shippings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipping_ShippingCompanyId",
                table: "Shippings",
                newName: "IX_Shippings_ShippingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipping_OrderId",
                table: "Shippings",
                newName: "IX_Shippings_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipping_AddressId",
                table: "Shippings",
                newName: "IX_Shippings_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingCompanies",
                table: "ShippingCompanies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingProduct_Shippings_ShippingId",
                table: "ShippingProduct",
                column: "ShippingId",
                principalTable: "Shippings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Addresses_AddressId",
                table: "Shippings",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_AspNetUsers_UserId",
                table: "Shippings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shippings_ShippingCompanies_ShippingCompanyId",
                table: "Shippings",
                column: "ShippingCompanyId",
                principalTable: "ShippingCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingProduct_Shippings_ShippingId",
                table: "ShippingProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Addresses_AddressId",
                table: "Shippings");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_AspNetUsers_UserId",
                table: "Shippings");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_Orders_OrderId",
                table: "Shippings");

            migrationBuilder.DropForeignKey(
                name: "FK_Shippings_ShippingCompanies_ShippingCompanyId",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shippings",
                table: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingCompanies",
                table: "ShippingCompanies");

            migrationBuilder.RenameTable(
                name: "Shippings",
                newName: "Shipping");

            migrationBuilder.RenameTable(
                name: "ShippingCompanies",
                newName: "ShippingCompany");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_UserId",
                table: "Shipping",
                newName: "IX_Shipping_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_ShippingCompanyId",
                table: "Shipping",
                newName: "IX_Shipping_ShippingCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_OrderId",
                table: "Shipping",
                newName: "IX_Shipping_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Shippings_AddressId",
                table: "Shipping",
                newName: "IX_Shipping_AddressId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipping",
                table: "Shipping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingCompany",
                table: "ShippingCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_Addresses_AddressId",
                table: "Shipping",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_AspNetUsers_UserId",
                table: "Shipping",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_Orders_OrderId",
                table: "Shipping",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipping_ShippingCompany_ShippingCompanyId",
                table: "Shipping",
                column: "ShippingCompanyId",
                principalTable: "ShippingCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingProduct_Shipping_ShippingId",
                table: "ShippingProduct",
                column: "ShippingId",
                principalTable: "Shipping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
