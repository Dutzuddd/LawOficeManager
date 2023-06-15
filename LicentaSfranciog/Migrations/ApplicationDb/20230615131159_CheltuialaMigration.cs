using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicentaSfranciog.Migrations.ApplicationDb
{
    public partial class CheltuialaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.CreateTable(
                name: "Cheltuieli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titlu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Persoana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cheltuieli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cheltuieli_Proces_ProcesId",
                        column: x => x.ProcesId,
                        principalTable: "Proces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cheltuieli_ProcesId",
                table: "Cheltuieli",
                column: "ProcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cheltuieli");

                       
        }
    }
}
