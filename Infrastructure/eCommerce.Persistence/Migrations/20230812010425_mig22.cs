﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Shippings",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "State",
                table: "Shippings",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
