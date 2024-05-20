using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEins.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Menge = table.Column<double>(type: "float", nullable: false),
                    ProdukteId = table.Column<int>(type: "int", nullable: false),
                    KündeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestellung_Künde_KündeId",
                        column: x => x.KündeId,
                        principalTable: "Künde",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestellung_Produkte_ProdukteId",
                        column: x => x.ProdukteId,
                        principalTable: "Produkte",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestellung_KündeId",
                table: "Bestellung",
                column: "KündeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellung_ProdukteId",
                table: "Bestellung",
                column: "ProdukteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bestellung");
        }
    }
}
