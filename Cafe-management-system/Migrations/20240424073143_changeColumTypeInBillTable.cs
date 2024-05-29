using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe_management_system.Migrations
{
    public partial class changeColumTypeInBillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Bills_BillId",
                table: "BillProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Products_ProductId",
                table: "BillProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct");

            migrationBuilder.RenameTable(
                name: "BillProduct",
                newName: "BillProducts");

            migrationBuilder.RenameIndex(
                name: "IX_BillProduct_ProductId",
                table: "BillProducts",
                newName: "IX_BillProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BillProduct_BillId",
                table: "BillProducts",
                newName: "IX_BillProducts_BillId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Bills",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Products_ProductId",
                table: "BillProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Products_ProductId",
                table: "BillProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts");

            migrationBuilder.RenameTable(
                name: "BillProducts",
                newName: "BillProduct");

            migrationBuilder.RenameIndex(
                name: "IX_BillProducts_ProductId",
                table: "BillProduct",
                newName: "IX_BillProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BillProducts_BillId",
                table: "BillProduct",
                newName: "IX_BillProduct_BillId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreationDate",
                table: "Bills",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BillProduct_Bills_BillId",
                table: "BillProduct",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProduct_Products_ProductId",
                table: "BillProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
