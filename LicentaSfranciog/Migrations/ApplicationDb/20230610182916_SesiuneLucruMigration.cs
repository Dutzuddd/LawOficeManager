using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicentaSfranciog.Migrations.ApplicationDb
{
    public partial class SesiuneLucruMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Termene",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SeiuniDosar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avocat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    numarOre = table.Column<int>(type: "int", nullable: false),
                    ProcesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeiuniDosar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeiuniDosar_Proces_ProcesId",
                        column: x => x.ProcesId,
                        principalTable: "Proces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeiuniDosar_ProcesId",
                table: "SeiuniDosar",
                column: "ProcesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeiuniDosar");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "Termene",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
