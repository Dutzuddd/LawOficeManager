using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicentaSfranciog.Migrations.ApplicationDb
{
    public partial class RapoarteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rapoarte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeProces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OreLucrate = table.Column<int>(type: "int", nullable: false),
                    Facturat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cheltuieli = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataRaport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rapoarte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rapoarte_Proces_ProcesId",
                        column: x => x.ProcesId,
                        principalTable: "Proces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rapoarte_ProcesId",
                table: "Rapoarte",
                column: "ProcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rapoarte");
        }
    }
}
