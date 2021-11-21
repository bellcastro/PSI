using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriMais.Migrations
{
    public partial class ficha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Peso = table.Column<string>(type: "TEXT", nullable: false),
                    Altura = table.Column<string>(type: "TEXT", nullable: false),
                    QuantidadeAF = table.Column<string>(type: "TEXT", nullable: false),
                    Rotina = table.Column<string>(type: "TEXT", nullable: false),
                    AtividadeF = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ficha");
        }
    }
}
