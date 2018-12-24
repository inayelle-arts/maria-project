using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class NullableFKTaskToHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_History_HistoryId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "HistoryId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_History_HistoryId",
                table: "Tasks",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_History_HistoryId",
                table: "Tasks");

            migrationBuilder.AlterColumn<int>(
                name: "HistoryId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_History_HistoryId",
                table: "Tasks",
                column: "HistoryId",
                principalTable: "History",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
