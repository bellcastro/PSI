using Microsoft.EntityFrameworkCore.Migrations;

namespace NutriMais.Migrations
{
    public partial class configuracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativado",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ENutricionista",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NutricionistaId",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_NutricionistaId",
                table: "AspNetUsers",
                column: "NutricionistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_NutricionistaId",
                table: "AspNetUsers",
                column: "NutricionistaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_NutricionistaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_NutricionistaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ativado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ENutricionista",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NutricionistaId",
                table: "AspNetUsers");
        }
    }
}
