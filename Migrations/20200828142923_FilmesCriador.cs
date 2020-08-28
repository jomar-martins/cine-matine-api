using Microsoft.EntityFrameworkCore.Migrations;

namespace cine_matine_api.Migrations
{
    public partial class FilmesCriador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                table: "Filme",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filme_CriadorId",
                table: "Filme",
                column: "CriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Users_CriadorId",
                table: "Filme",
                column: "CriadorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Users_CriadorId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_CriadorId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Filme");
        }
    }
}
