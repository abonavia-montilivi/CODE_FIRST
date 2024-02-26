using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST_Fogliano_Eloy.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeCode",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLines_productLine",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerNumber",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CustomerNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OfficeCode",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "productLine",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductLineKey",
                table: "Products",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "CustomerKey",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OfficeKey",
                table: "Employees",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReportsToKey",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Customers",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SalesRepKey",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerKey",
                table: "Orders",
                column: "CustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeKey",
                table: "Employees",
                column: "OfficeKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeKey",
                table: "Employees",
                column: "OfficeKey",
                principalTable: "Offices",
                principalColumn: "OfficeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerKey",
                table: "Orders",
                column: "CustomerKey",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductLines_productLine",
                table: "Products",
                column: "productLine",
                principalTable: "ProductLines",
                principalColumn: "productLine",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Offices_OfficeKey",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerKey",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductLines_productLine",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerKey",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OfficeKey",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProductLineKey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerKey",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OfficeKey",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ReportsToKey",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SalesRepKey",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "productLine",
                table: "Products",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "CustomerNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OfficeCode",
                table: "Employees",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerNumber",
                table: "Orders",
                column: "CustomerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeCode",
                table: "Employees",
                column: "OfficeCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Offices_OfficeCode",
                table: "Employees",
                column: "OfficeCode",
                principalTable: "Offices",
                principalColumn: "OfficeCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerNumber",
                table: "Orders",
                column: "CustomerNumber",
                principalTable: "Customers",
                principalColumn: "CustomerNumber",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductLines_productLine",
                table: "Products",
                column: "productLine",
                principalTable: "ProductLines",
                principalColumn: "productLine",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
