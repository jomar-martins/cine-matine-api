using Microsoft.EntityFrameworkCore.Migrations;

namespace cine_matine_api.Migrations
{
    public partial class ComentsNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Nota",
                table: "Comentario",
                type: "numeric(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Comentario");
        }
    }
}
