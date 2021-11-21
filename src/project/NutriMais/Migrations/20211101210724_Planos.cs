using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriMais.Migrations
{
    public partial class Planos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicioPlano = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFimPlano = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ObservacoesPlano = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TextoReceita = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanosSemanal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IdPlano = table.Column<int>(type: "INTEGER", nullable: false),
                    DiaDaSemana = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanoTexto = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanosSemanal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanosSemanal_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanosSemanal_Planos_IdPlano",
                        column: x => x.IdPlano,
                        principalTable: "Planos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planos_IdUsuario",
                table: "Planos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosSemanal_IdPlano",
                table: "PlanosSemanal",
                column: "IdPlano");

            migrationBuilder.CreateIndex(
                name: "IX_PlanosSemanal_UserId",
                table: "PlanosSemanal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_IdUsuario",
                table: "Receita",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanosSemanal");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "Planos");
        }
    }
}
