using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeShop.DataAccess.Migrations
{
    public partial class perfumeproducttypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeProductType_Perfumes_PerfumeId",
                table: "PerfumeProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeProductType_ProductTypes_ProductTypeId",
                table: "PerfumeProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfumeProductType",
                table: "PerfumeProductType");

            migrationBuilder.RenameTable(
                name: "PerfumeProductType",
                newName: "PerfumeProductTypes");

            migrationBuilder.RenameIndex(
                name: "IX_PerfumeProductType_ProductTypeId",
                table: "PerfumeProductTypes",
                newName: "IX_PerfumeProductTypes_ProductTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfumeProductTypes",
                table: "PerfumeProductTypes",
                columns: new[] { "PerfumeId", "ProductTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeProductTypes_Perfumes_PerfumeId",
                table: "PerfumeProductTypes",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeProductTypes_ProductTypes_ProductTypeId",
                table: "PerfumeProductTypes",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeProductTypes_Perfumes_PerfumeId",
                table: "PerfumeProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfumeProductTypes_ProductTypes_ProductTypeId",
                table: "PerfumeProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PerfumeProductTypes",
                table: "PerfumeProductTypes");

            migrationBuilder.RenameTable(
                name: "PerfumeProductTypes",
                newName: "PerfumeProductType");

            migrationBuilder.RenameIndex(
                name: "IX_PerfumeProductTypes_ProductTypeId",
                table: "PerfumeProductType",
                newName: "IX_PerfumeProductType_ProductTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PerfumeProductType",
                table: "PerfumeProductType",
                columns: new[] { "PerfumeId", "ProductTypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeProductType_Perfumes_PerfumeId",
                table: "PerfumeProductType",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfumeProductType_ProductTypes_ProductTypeId",
                table: "PerfumeProductType",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
