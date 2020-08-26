using Microsoft.EntityFrameworkCore.Migrations;

namespace cine_matine_api.Migrations
{
    public partial class FilmesNota : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_generoId",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "generoId",
                table: "Filme",
                newName: "GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_generoId",
                table: "Filme",
                newName: "IX_Filme_GeneroId");

            migrationBuilder.AddColumn<decimal>(
                name: "Nota",
                table: "Filme",
                type: "numeric(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_GeneroId",
                table: "Filme",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Genero_GeneroId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Filme");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Filme",
                newName: "generoId");

            migrationBuilder.RenameIndex(
                name: "IX_Filme_GeneroId",
                table: "Filme",
                newName: "IX_Filme_generoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Genero_generoId",
                table: "Filme",
                column: "generoId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
