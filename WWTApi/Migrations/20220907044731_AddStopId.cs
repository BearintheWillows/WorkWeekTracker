using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWTApi.Migrations
{
    public partial class AddStopId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StopId",
                table: "DailyRoutes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek",
                table: "DailyRoutes",
                columns: new[] { "StopId", "DayOfWeek" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DailyRoutes_StopId_DayOfWeek",
                table: "DailyRoutes");

            migrationBuilder.DropColumn(
                name: "StopId",
                table: "DailyRoutes");
        }
    }
}
