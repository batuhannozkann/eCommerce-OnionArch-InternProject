using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductOrder",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductOrder",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductOrder",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductOrder",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "ProductCategory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductCategory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductCategory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "LikedProduct",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "LikedProduct",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "LikedProduct",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LikedProduct",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "LikedProduct",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "OrderId", "ProductId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId", "Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                columns: new[] { "ProductId", "CustomerId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProductOrder");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LikedProduct");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "LikedProduct");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "LikedProduct");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LikedProduct");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "LikedProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductOrder",
                table: "ProductOrder",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikedProduct",
                table: "LikedProduct",
                columns: new[] { "ProductId", "CustomerId" });
        }
    }
}
