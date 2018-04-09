using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Persistence.Migrations
{
    public partial class ayDio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Costumer_CostumerId",
                table: "Invoice");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_CostumerId",
                table: "Invoice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_ProductId",
                table: "InvoiceDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CompanyId",
                table: "Invoice",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CostumerId",
                table: "Invoice",
                column: "CostumerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Company_CompanyId",
                table: "Invoice",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Costumer_CostumerId",
                table: "Invoice",
                column: "CostumerId",
                principalTable: "Costumer",
                principalColumn: "CostumerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Invoice_InvoiceId",
                table: "InvoiceDetail",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetail_Product_ProductId",
                table: "InvoiceDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
