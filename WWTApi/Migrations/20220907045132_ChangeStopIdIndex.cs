using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWTApi.Migrations
{
    public partial class ChangeStopIdIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek",
                table: "DailyRoutes");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek_RunId",
                table: "DailyRoutes",
                columns: new[] { "StopId", "DayOfWeek", "RunId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek_RunId",
                table: "DailyRoutes");

            migrationBuilder.CreateIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek",
                table: "DailyRoutes",
                columns: new[] { "StopId", "DayOfWeek" },
                unique: true);
        }
    }
}
