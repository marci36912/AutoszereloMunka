using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoszerelo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ugyfelek",
                columns: table => new
                {
                    Ugyfelszam = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lakcim = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugyfelek", x => x.Ugyfelszam);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Munkak",
                columns: table => new
                {
                    MunkaAzonosito = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UgyfelSzam = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rendszam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GyartasiEv = table.Column<DateOnly>(type: "date", nullable: false),
                    MunkaKategoria = table.Column<int>(type: "int", nullable: false),
                    HibaRovidLeirasa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HibaSulyossaga = table.Column<int>(type: "int", nullable: false),
                    MunkaAllapot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Munkak", x => x.MunkaAzonosito);
                    table.ForeignKey(
                        name: "FK_Munkak_Ugyfelek_UgyfelSzam",
                        column: x => x.UgyfelSzam,
                        principalTable: "Ugyfelek",
                        principalColumn: "Ugyfelszam",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Munkak_UgyfelSzam",
                table: "Munkak",
                column: "UgyfelSzam");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Munkak");

            migrationBuilder.DropTable(
                name: "Ugyfelek");
        }
    }
}
