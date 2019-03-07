using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web_back_produktevaluering.web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evalueringer",
                columns: table => new
                {
                    EvalueringId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Navn = table.Column<string>(nullable: false),
                    Produkt = table.Column<string>(nullable: false),
                    Karakter = table.Column<int>(nullable: false),
                    Oprettet = table.Column<DateTime>(nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evalueringer", x => x.EvalueringId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evalueringer");
        }
    }
}
