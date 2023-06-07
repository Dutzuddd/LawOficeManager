using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicentaSfranciog.Migrations.ApplicationDb
{
    public partial class ProcesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Partile = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Obiect = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Solutie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OreLucrate = table.Column<int>(type: "int", nullable: false),
                    clientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proces_Client_clientId",
                        column: x => x.clientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proces_clientId",
                table: "Proces",
                column: "clientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proces");
        }
    }
}
