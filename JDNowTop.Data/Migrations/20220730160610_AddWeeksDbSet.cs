using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JDNowTop.Data.Migrations
{
    public partial class AddWeeksDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Songs_SongMapName",
                table: "Positions");

            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Week_WeekId",
                table: "Positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_WeekId",
                table: "Position",
                newName: "IX_Position_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_Positions_SongMapName",
                table: "Position",
                newName: "IX_Position_SongMapName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Songs_SongMapName",
                table: "Position",
                column: "SongMapName",
                principalTable: "Songs",
                principalColumn: "MapName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Position_Week_WeekId",
                table: "Position",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Position_Songs_SongMapName",
                table: "Position");

            migrationBuilder.DropForeignKey(
                name: "FK_Position_Week_WeekId",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameIndex(
                name: "IX_Position_WeekId",
                table: "Positions",
                newName: "IX_Positions_WeekId");

            migrationBuilder.RenameIndex(
                name: "IX_Position_SongMapName",
                table: "Positions",
                newName: "IX_Positions_SongMapName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Songs_SongMapName",
                table: "Positions",
                column: "SongMapName",
                principalTable: "Songs",
                principalColumn: "MapName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Week_WeekId",
                table: "Positions",
                column: "WeekId",
                principalTable: "Week",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
