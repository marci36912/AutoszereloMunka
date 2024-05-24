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
                name: "Munkak",
                columns: table => new
                {
                    MunkaAzonosito = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UgyfelSzam = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Rendszam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GyartasiEv = table.Column<DateOnly>(type: "date", nullable: false),
                    MunkaKategoria = table.Column<int>(type: "int", nullable: false),
                    HibaRovidLeirasa = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HibaSulyossaga = table.Column<int>(type: "int", nullable: false),
                    MunkaAllapot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Munkak", x => x.MunkaAzonosito);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ugyfelek",
                columns: table => new
                {
                    Ugyfelszam = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Nev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lakcim = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugyfelek", x => x.Ugyfelszam);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
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
