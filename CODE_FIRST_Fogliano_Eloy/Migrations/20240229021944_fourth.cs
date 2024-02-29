using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CODE_FIRST_Fogliano_Eloy.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "ProductLines",
                type: "mediumblob",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "mediumblob");

            migrationBuilder.AlterColumn<string>(
                name: "HtmlDescription",
                table: "ProductLines",
                type: "mediumtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "mediumtext");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "ProductLines",
                type: "mediumblob",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "mediumblob",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HtmlDescription",
                table: "ProductLines",
                type: "mediumtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "mediumtext",
                oldNullable: true);
        }
    }
}
