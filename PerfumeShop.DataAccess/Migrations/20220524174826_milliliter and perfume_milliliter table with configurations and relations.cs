using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PerfumeShop.DataAccess.Migrations
{
    public partial class milliliterandperfume_millilitertablewithconfigurationsandrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Milliliters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milliliters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfumeMilliliters",
                columns: table => new
                {
                    PerfumeId = table.Column<int>(type: "int", nullable: false),
                    MilliliterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfumeMilliliters", x => new { x.PerfumeId, x.MilliliterId });
                    table.ForeignKey(
                        name: "FK_PerfumeMilliliters_Milliliters_MilliliterId",
                        column: x => x.MilliliterId,
                        principalTable: "Milliliters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfumeMilliliters_Perfumes_PerfumeId",
                        column: x => x.PerfumeId,
                        principalTable: "Perfumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfumeMilliliters_MilliliterId",
                table: "PerfumeMilliliters",
                column: "MilliliterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfumeMilliliters");

            migrationBuilder.DropTable(
                name: "Milliliters");
        }
    }
}
