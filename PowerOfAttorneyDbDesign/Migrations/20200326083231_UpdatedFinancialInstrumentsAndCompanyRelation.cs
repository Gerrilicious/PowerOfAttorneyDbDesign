using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PowerOfAttorneyDbDesign.Migrations
{
    public partial class UpdatedFinancialInstrumentsAndCompanyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "FinancialInstrument",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FinancialInstrument_CompanyId",
                table: "FinancialInstrument",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialInstrument_Company_CompanyId",
                table: "FinancialInstrument",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialInstrument_Company_CompanyId",
                table: "FinancialInstrument");

            migrationBuilder.DropIndex(
                name: "IX_FinancialInstrument_CompanyId",
                table: "FinancialInstrument");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "FinancialInstrument");
        }
    }
}
