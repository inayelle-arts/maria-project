using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
	public partial class TaskModifications : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_HistoryPoint_History_HistoryId",
					"HistoryPoint");

			migrationBuilder.DropForeignKey(
					"FK_Tasks_Users_AssigneeId",
					"Tasks");

			migrationBuilder.DropForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks");

			migrationBuilder.DropPrimaryKey(
					"PK_HistoryPoint",
					"HistoryPoint");

			migrationBuilder.DropPrimaryKey(
					"PK_History",
					"History");

			migrationBuilder.RenameTable(
					"HistoryPoint",
					newName: "HistoryPoints");

			migrationBuilder.RenameTable(
					"History",
					newName: "Histories");

			migrationBuilder.RenameIndex(
					"IX_HistoryPoint_HistoryId",
					table: "HistoryPoints",
					newName: "IX_HistoryPoints_HistoryId");

			migrationBuilder.AlterColumn<int>(
					"AssigneeId",
					"Tasks",
					nullable: true,
					oldClrType: typeof(int));

			migrationBuilder.AddColumn<int>(
					"CreatorId",
					"Tasks",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
					"PK_HistoryPoints",
					"HistoryPoints",
					"Id");

			migrationBuilder.AddPrimaryKey(
					"PK_Histories",
					"Histories",
					"Id");

			migrationBuilder.CreateIndex(
					"IX_Tasks_CreatorId",
					"Tasks",
					"CreatorId");

			migrationBuilder.AddForeignKey(
					"FK_HistoryPoints_Histories_HistoryId",
					"HistoryPoints",
					"HistoryId",
					"Histories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_Users_AssigneeId",
					"Tasks",
					"AssigneeId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_Users_CreatorId",
					"Tasks",
					"CreatorId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_Histories_HistoryId",
					"Tasks",
					"HistoryId",
					"Histories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_HistoryPoints_Histories_HistoryId",
					"HistoryPoints");

			migrationBuilder.DropForeignKey(
					"FK_Tasks_Users_AssigneeId",
					"Tasks");

			migrationBuilder.DropForeignKey(
					"FK_Tasks_Users_CreatorId",
					"Tasks");

			migrationBuilder.DropForeignKey(
					"FK_Tasks_Histories_HistoryId",
					"Tasks");

			migrationBuilder.DropIndex(
					"IX_Tasks_CreatorId",
					"Tasks");

			migrationBuilder.DropPrimaryKey(
					"PK_HistoryPoints",
					"HistoryPoints");

			migrationBuilder.DropPrimaryKey(
					"PK_Histories",
					"Histories");

			migrationBuilder.DropColumn(
					"CreatorId",
					"Tasks");

			migrationBuilder.RenameTable(
					"HistoryPoints",
					newName: "HistoryPoint");

			migrationBuilder.RenameTable(
					"Histories",
					newName: "History");

			migrationBuilder.RenameIndex(
					"IX_HistoryPoints_HistoryId",
					table: "HistoryPoint",
					newName: "IX_HistoryPoint_HistoryId");

			migrationBuilder.AlterColumn<int>(
					"AssigneeId",
					"Tasks",
					nullable: false,
					oldClrType: typeof(int),
					oldNullable: true);

			migrationBuilder.AddPrimaryKey(
					"PK_HistoryPoint",
					"HistoryPoint",
					"Id");

			migrationBuilder.AddPrimaryKey(
					"PK_History",
					"History",
					"Id");

			migrationBuilder.AddForeignKey(
					"FK_HistoryPoint_History_HistoryId",
					"HistoryPoint",
					"HistoryId",
					"History",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_Users_AssigneeId",
					"Tasks",
					"AssigneeId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Tasks_History_HistoryId",
					"Tasks",
					"HistoryId",
					"History",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);
		}
	}
}