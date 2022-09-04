using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WWTApi.Migrations
{
    public partial class dailyRouteNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutePlans_Runs_RunId",
                table: "DailyRoutePlans");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutePlans_Shops_ShopId",
                table: "DailyRoutePlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyRoutePlans",
                table: "DailyRoutePlans");

            migrationBuilder.RenameTable(
                name: "DailyRoutePlans",
                newName: "DailyRoutes");

            migrationBuilder.RenameIndex(
                name: "IX_DailyRoutePlans_ShopId_DayOfWeek",
                table: "DailyRoutes",
                newName: "IX_DailyRoutes_ShopId_DayOfWeek");

            migrationBuilder.AlterColumn<string>(
                name: "LocationArea",
                table: "Runs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyRoutes",
                table: "DailyRoutes",
                columns: new[] { "RunId", "ShopId", "DayOfWeek" });

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutes_Shops_ShopId",
                table: "DailyRoutes",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutes_Runs_RunId",
                table: "DailyRoutes");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyRoutes_Shops_ShopId",
                table: "DailyRoutes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DailyRoutes",
                table: "DailyRoutes");

            migrationBuilder.RenameTable(
                name: "DailyRoutes",
                newName: "DailyRoutePlans");

            migrationBuilder.RenameIndex(
                name: "IX_DailyRoutes_ShopId_DayOfWeek",
                table: "DailyRoutePlans",
                newName: "IX_DailyRoutePlans_ShopId_DayOfWeek");

            migrationBuilder.AlterColumn<string>(
                name: "LocationArea",
                table: "Runs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DailyRoutePlans",
                table: "DailyRoutePlans",
                columns: new[] { "RunId", "ShopId", "DayOfWeek" });

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutePlans_Runs_RunId",
                table: "DailyRoutePlans",
                column: "RunId",
                principalTable: "Runs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyRoutePlans_Shops_ShopId",
                table: "DailyRoutePlans",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
