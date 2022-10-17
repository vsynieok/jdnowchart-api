using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JDNowTop.Data.Migrations
{
    public partial class AddStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Songs_SongMapName",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "SongMapName",
                table: "Positions",
                newName: "MapName");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_SongMapName",
                table: "Positions",
                newName: "IX_Positions_MapName");

            migrationBuilder.AddColumn<int>(
                name: "TotalPlays",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Delta",
                table: "Positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Songs_MapName",
                table: "Positions",
                column: "MapName",
                principalTable: "Songs",
                principalColumn: "MapName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Songs_MapName",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "TotalPlays",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Delta",
                table: "Positions");

            migrationBuilder.RenameColumn(
                name: "MapName",
                table: "Positions",
                newName: "SongMapName");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_MapName",
                table: "Positions",
                newName: "IX_Positions_SongMapName");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Songs_SongMapName",
                table: "Positions",
                column: "SongMapName",
                principalTable: "Songs",
                principalColumn: "MapName",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
