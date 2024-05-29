using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe_management_system.Migrations
{
    public partial class configurePaymentMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_PaymentMethod_PaymentMethodId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Users_UserId",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Bill_BillId",
                table: "BillProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProduct_Products_ProductId",
                table: "BillProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bill",
                table: "Bill");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                newName: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "BillProduct",
                newName: "BillProducts");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "Bills");

            migrationBuilder.RenameIndex(
                name: "IX_BillProduct_ProductId",
                table: "BillProducts",
                newName: "IX_BillProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BillProduct_BillId",
                table: "BillProducts",
                newName: "IX_BillProducts_BillId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_UserId",
                table: "Bills",
                newName: "IX_Bills_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_PaymentMethodId",
                table: "Bills",
                newName: "IX_Bills_PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bills",
                column: "BillId");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "description" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "Bank" },
                    { 3, "Creadit card" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts",
                column: "BillId",
                principalTable: "Bills",
                principalColumn: "BillId",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProducts_Products_ProductId",
                table: "BillProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_PaymentMethods_PaymentMethodId",
                table: "Bills",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.SetNull, onUpdate: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Users_UserId",
                table: "Bills",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull, onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Bills_BillId",
                table: "BillProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_BillProducts_Products_ProductId",
                table: "BillProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_PaymentMethods_PaymentMethodId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Users_UserId",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillProducts",
                table: "BillProducts");

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "PaymentMethodId",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "Bills",
                newName: "Bill");

            migrationBuilder.RenameTable(
                name: "BillProducts",
                newName: "BillProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_UserId",
                table: "Bill",
                newName: "IX_Bill_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bills_PaymentMethodId",
                table: "Bill",
                newName: "IX_Bill_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_BillProducts_ProductId",
                table: "BillProduct",
                newName: "IX_BillProduct_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_BillProducts_BillId",
                table: "BillProduct",
                newName: "IX_BillProduct_BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bill",
                table: "Bill",
                column: "BillId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillProduct",
                table: "BillProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_PaymentMethod_PaymentMethodId",
                table: "Bill",
                column: "PaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Users_UserId",
                table: "Bill",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BillProduct_Bill_BillId",
                table: "BillProduct",
                column: "BillId",
                principalTable: "Bill",
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
