using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Generos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroLibro_Genero_GenerosCodigo",
                table: "GeneroLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "Generos");

            migrationBuilder.RenameColumn(
                name: "GenerosCodigo",
                table: "GeneroLibro",
                newName: "GeneroCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generos",
                table: "Generos",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroLibro_Generos_GeneroCodigo",
                table: "GeneroLibro",
                column: "GeneroCodigo",
                principalTable: "Generos",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroLibro_Generos_GeneroCodigo",
                table: "GeneroLibro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generos",
                table: "Generos");

            migrationBuilder.RenameTable(
                name: "Generos",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "GeneroCodigo",
                table: "GeneroLibro",
                newName: "GenerosCodigo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroLibro_Genero_GenerosCodigo",
                table: "GeneroLibro",
                column: "GenerosCodigo",
                principalTable: "Genero",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
