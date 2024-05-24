using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autoszerelo.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Munkak_UgyfelSzam",
                table: "Munkak",
                column: "UgyfelSzam");

            migrationBuilder.AddForeignKey(
                name: "FK_Munkak_Ugyfelek_UgyfelSzam",
                table: "Munkak",
                column: "UgyfelSzam",
                principalTable: "Ugyfelek",
                principalColumn: "Ugyfelszam",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Munkak_Ugyfelek_UgyfelSzam",
                table: "Munkak");

            migrationBuilder.DropIndex(
                name: "IX_Munkak_UgyfelSzam",
                table: "Munkak");
        }
    }
}
