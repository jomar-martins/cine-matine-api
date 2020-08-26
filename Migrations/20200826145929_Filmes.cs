using Microsoft.EntityFrameworkCore.Migrations;

namespace cine_matine_api.Migrations
{
    public partial class Filmes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOriginal = table.Column<string>(nullable: true),
                    NomeBrasil = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Ano = table.Column<short>(nullable: false),
                    Diretor = table.Column<string>(nullable: true),
                    LinkDiretor = table.Column<string>(nullable: true),
                    generoId = table.Column<int>(nullable: true),
                    LinkImdb = table.Column<string>(nullable: true),
                    LinkAlternativo = table.Column<string>(nullable: true),
                    LinkYoutube = table.Column<string>(nullable: true),
                    ImageURI = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Genero_generoId",
                        column: x => x.generoId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_generoId",
                table: "Filme",
                column: "generoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Genero");
        }
    }
}
