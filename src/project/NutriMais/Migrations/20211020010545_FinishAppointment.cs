using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace NutriMais.Migrations
{
    public partial class FinishAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(name: "EndsAt", table: "Appointments", type: "TEXT", nullable: true);
            migrationBuilder.AddColumn<DateTime>(name: "Status", table: "Appointments", type: "INTEGER", nullable: true);
            migrationBuilder.AddColumn<DateTime>(name: "Link", table: "Appointments", type: "TEXT", nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "EndsAt", table: "Appointments");
            migrationBuilder.DropColumn(name: "Status", table: "Appointments");
            migrationBuilder.DropColumn(name: "Link", table: "Appointments");
        }
    }
}
