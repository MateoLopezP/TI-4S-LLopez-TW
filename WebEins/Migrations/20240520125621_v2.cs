﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebEins.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Künde",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personalnummer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ausweisidentificactionsnummer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Künde", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Künde");
        }
    }
}
