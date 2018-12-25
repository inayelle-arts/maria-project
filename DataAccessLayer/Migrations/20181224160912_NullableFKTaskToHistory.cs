using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
	public partial class NullableFKTaskToHistory : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks");

			migrationBuilder.AlterColumn<int>(
					"HistoryId",
					"Tasks",
					nullable: true,
					oldClrType: typeof(int));

			migrationBuilder.AddForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks",
					"HistoryId",
					"History",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks");

			migrationBuilder.AlterColumn<int>(
					"HistoryId",
					"Tasks",
					nullable: false,
					oldClrType: typeof(int),
					oldNullable: true);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks",
					"HistoryId",
					"History",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
		}
	}
}