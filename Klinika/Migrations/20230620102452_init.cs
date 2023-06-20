using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Klinika.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ljekar",
                columns: table => new
                {
                    LjekarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Titula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ljekar", x => x.LjekarId);
                });

            migrationBuilder.CreateTable(
                name: "Pacijent",
                columns: table => new
                {
                    PacijentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacijent", x => x.PacijentId);
                });

            migrationBuilder.CreateTable(
                name: "Prijem",
                columns: table => new
                {
                    PrijemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPrijema = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PacijentId = table.Column<int>(type: "int", nullable: false),
                    LjekarId = table.Column<int>(type: "int", nullable: false),
                    HitniPrijem = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijem", x => x.PrijemId);
                    table.ForeignKey(
                        name: "FK_Prijem_Ljekar_LjekarId",
                        column: x => x.LjekarId,
                        principalTable: "Ljekar",
                        principalColumn: "LjekarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijem_Pacijent_PacijentId",
                        column: x => x.PacijentId,
                        principalTable: "Pacijent",
                        principalColumn: "PacijentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nalaz",
                columns: table => new
                {
                    NalazId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumKreiranja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrijemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nalaz", x => x.NalazId);
                    table.ForeignKey(
                        name: "FK_Nalaz_Prijem_PrijemId",
                        column: x => x.PrijemId,
                        principalTable: "Prijem",
                        principalColumn: "PrijemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nalaz_PrijemId",
                table: "Nalaz",
                column: "PrijemId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijem_LjekarId",
                table: "Prijem",
                column: "LjekarId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijem_PacijentId",
                table: "Prijem",
                column: "PacijentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nalaz");

            migrationBuilder.DropTable(
                name: "Prijem");

            migrationBuilder.DropTable(
                name: "Ljekar");

            migrationBuilder.DropTable(
                name: "Pacijent");
        }
    }
}
