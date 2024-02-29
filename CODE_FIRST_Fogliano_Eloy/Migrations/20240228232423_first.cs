using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST_Fogliano_Eloy.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeCode = table.Column<string>(nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Territory = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeCode);
                });

            migrationBuilder.CreateTable(
                name: "ProductLines",
                columns: table => new
                {
                    productLine = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    TextDescription = table.Column<string>(type: "varchar(4000)", nullable: false),
                    HtmlDescription = table.Column<string>(type: "mediumtext", nullable: false),
                    Image = table.Column<byte[]>(type: "mediumblob", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLines", x => x.productLine);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    OfficeKey = table.Column<string>(type: "varchar(10)", nullable: false),
                    ReportsToKey = table.Column<int>(nullable: false),
                    ReportsToEmployeeNumber = table.Column<int>(nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                    table.ForeignKey(
                        name: "FK_Employees_Offices_OfficeKey",
                        column: x => x.OfficeKey,
                        principalTable: "Offices",
                        principalColumn: "OfficeCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ReportsToEmployeeNumber",
                        column: x => x.ReportsToEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(70)", nullable: false),
                    ProductLineId = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ProductScale = table.Column<string>(type: "varchar(10)", nullable: false),
                    ProductVendor = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProductDescription = table.Column<string>(type: "text", nullable: false),
                    QuantityInStock = table.Column<short>(type: "smallint", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MSRP = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductCode);
                    table.ForeignKey(
                        name: "FK_Products_ProductLines_ProductLineId",
                        column: x => x.ProductLineId,
                        principalTable: "ProductLines",
                        principalColumn: "productLine",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactLastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ContactFirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "varchar(50)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(15)", nullable: false),
                    Country = table.Column<string>(type: "varchar(50)", nullable: false),
                    SalesRepKey = table.Column<int>(nullable: false),
                    SalesRepEmployeeNumber = table.Column<int>(nullable: false),
                    CreditLimit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerNumber);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_SalesRepEmployeeNumber",
                        column: x => x.SalesRepEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<string>(type: "varchar(15)", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: false),
                    CustomerKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerKey",
                        column: x => x.CustomerKey,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    CustomerNumber = table.Column<int>(nullable: false),
                    CheckNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => new { x.CustomerNumber, x.CheckNumber });
                    table.ForeignKey(
                        name: "FK_Payments_Customers_CustomerNumber",
                        column: x => x.CustomerNumber,
                        principalTable: "Customers",
                        principalColumn: "CustomerNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    QuantityOrdered = table.Column<int>(type: "int(11)", nullable: false),
                    PriceEach = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    OrderLineNumber = table.Column<short>(type: "smallint(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.OrderNumber, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Products",
                        principalColumn: "ProductCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SalesRepEmployeeNumber",
                table: "Customers",
                column: "SalesRepEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OfficeKey",
                table: "Employees",
                column: "OfficeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ReportsToEmployeeNumber",
                table: "Employees",
                column: "ReportsToEmployeeNumber");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductCode",
                table: "OrderDetails",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerKey",
                table: "Orders",
                column: "CustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductLineId",
                table: "Products",
                column: "ProductLineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductLines");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
