using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicentaSfranciog.Migrations.ApplicationDb
{
    public partial class EventUserMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Evenimente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evenimente_UserId",
                table: "Evenimente",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evenimente_AspNetUsers_UserId",
                table: "Evenimente",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evenimente_AspNetUsers_UserId",
                table: "Evenimente");

            migrationBuilder.DropIndex(
                name: "IX_Evenimente_UserId",
                table: "Evenimente");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Evenimente");
        }
    }
}
