using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST_Fogliano_Eloy.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customers",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "SalesRepKey",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SalesRepEmployeeNumber",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Customers",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Customers",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesRepKey",
                table: "Customers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SalesRepEmployeeNumber",
                table: "Customers",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "varchar(15)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressLine2",
                table: "Customers",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
