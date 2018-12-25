using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migrationBeforeKurenie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Boards",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_TeamId",
                table: "Boards",
                newName: "IX_Boards_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Columns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_BoardId",
                table: "Teams",
                column: "BoardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_CreatorId",
                table: "Columns",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_CreatorId",
                table: "Boards",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_CreatorId",
                table: "Boards",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Projects_ProjectId",
                table: "Boards",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Users_CreatorId",
                table: "Columns",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Boards_BoardId",
                table: "Teams",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_CreatorId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Projects_ProjectId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Users_CreatorId",
                table: "Columns");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Boards_BoardId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_BoardId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Columns_CreatorId",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Boards_CreatorId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Boards");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Boards",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Boards_ProjectId",
                table: "Boards",
                newName: "IX_Boards_TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
