using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
	public partial class migrationBeforeKurenie : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Boards_Teams_TeamId",
					"Boards");

			migrationBuilder.RenameColumn(
					"TeamId",
					"Boards",
					"ProjectId");

			migrationBuilder.RenameIndex(
					"IX_Boards_TeamId",
					table: "Boards",
					newName: "IX_Boards_ProjectId");

			migrationBuilder.AddColumn<int>(
					"BoardId",
					"Teams",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddColumn<int>(
					"CreatorId",
					"Columns",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddColumn<int>(
					"CreatorId",
					"Boards",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.CreateIndex(
					"IX_Teams_BoardId",
					"Teams",
					"BoardId",
					unique: true);

			migrationBuilder.CreateIndex(
					"IX_Columns_CreatorId",
					"Columns",
					"CreatorId");

			migrationBuilder.CreateIndex(
					"IX_Boards_CreatorId",
					"Boards",
					"CreatorId");

			migrationBuilder.AddForeignKey(
					"FK_Boards_Users_CreatorId",
					"Boards",
					"CreatorId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Boards_Projects_ProjectId",
					"Boards",
					"ProjectId",
					"Projects",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Columns_Users_CreatorId",
					"Columns",
					"CreatorId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Teams_Boards_BoardId",
					"Teams",
					"BoardId",
					"Boards",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Boards_Users_CreatorId",
					"Boards");

			migrationBuilder.DropForeignKey(
					"FK_Boards_Projects_ProjectId",
					"Boards");

			migrationBuilder.DropForeignKey(
					"FK_Columns_Users_CreatorId",
					"Columns");

			migrationBuilder.DropForeignKey(
					"FK_Teams_Boards_BoardId",
					"Teams");

			migrationBuilder.DropIndex(
					"IX_Teams_BoardId",
					"Teams");

			migrationBuilder.DropIndex(
					"IX_Columns_CreatorId",
					"Columns");

			migrationBuilder.DropIndex(
					"IX_Boards_CreatorId",
					"Boards");

			migrationBuilder.DropColumn(
					"BoardId",
					"Teams");

			migrationBuilder.DropColumn(
					"CreatorId",
					"Columns");

			migrationBuilder.DropColumn(
					"CreatorId",
					"Boards");

			migrationBuilder.RenameColumn(
					"ProjectId",
					"Boards",
					"TeamId");

			migrationBuilder.RenameIndex(
					"IX_Boards_ProjectId",
					table: "Boards",
					newName: "IX_Boards_TeamId");

			migrationBuilder.AddForeignKey(
					"FK_Boards_Teams_TeamId",
					"Boards",
					"TeamId",
					"Teams",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
		}
	}
}