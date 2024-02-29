using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST_Fogliano_Eloy.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ReportsToKey",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportsToEmployeeNumber",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeNumber",
                table: "Employees",
                column: "ReportsToEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeNumber",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ReportsToKey",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportsToEmployeeNumber",
                table: "Employees",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ReportsToEmployeeNumber",
                table: "Employees",
                column: "ReportsToEmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
