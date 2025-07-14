using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestellSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bestellungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Kunde = table.Column<string>(type: "TEXT", nullable: false),
                    Erstellungsdatum = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BestellPosition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProduktName = table.Column<string>(type: "TEXT", nullable: false),
                    EinzelPreis = table.Column<decimal>(type: "TEXT", nullable: false),
                    Anzahl = table.Column<int>(type: "INTEGER", nullable: false),
                    BestellungId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestellPosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BestellPosition_Bestellungen_BestellungId",
                        column: x => x.BestellungId,
                        principalTable: "Bestellungen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BestellPosition_BestellungId",
                table: "BestellPosition",
                column: "BestellungId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BestellPosition");

            migrationBuilder.DropTable(
                name: "Bestellungen");
        }
    }
}
