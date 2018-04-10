using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class iziDisplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Producto",
                table: "InvoiceDetail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "Invoice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Costumer",
                table: "Invoice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producto",
                table: "InvoiceDetail");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "Costumer",
                table: "Invoice");
        }
    }
}
