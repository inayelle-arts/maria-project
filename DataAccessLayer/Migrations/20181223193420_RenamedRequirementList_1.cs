using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RenamedRequirementList_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementList_RequirementICollectionId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementList_RequirementICollectionId",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Requirement_RequirementICollectionId",
                table: "Requirement");

            migrationBuilder.RenameColumn(
                name: "RequirementICollectionId",
                table: "Projects",
                newName: "RequirementListId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_RequirementICollectionId",
                table: "Projects",
                newName: "IX_Projects_RequirementListId");

            migrationBuilder.AddColumn<int>(
                name: "RequirementListId",
                table: "Requirement",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_RequirementListId",
                table: "Requirement",
                column: "RequirementListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_RequirementList_RequirementListId",
                table: "Projects",
                column: "RequirementListId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirement_RequirementList_RequirementListId",
                table: "Requirement",
                column: "RequirementListId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementList_RequirementListId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementList_RequirementListId",
                table: "Requirement");

            migrationBuilder.DropIndex(
                name: "IX_Requirement_RequirementListId",
                table: "Requirement");

            migrationBuilder.DropColumn(
                name: "RequirementListId",
                table: "Requirement");

            migrationBuilder.RenameColumn(
                name: "RequirementListId",
                table: "Projects",
                newName: "RequirementICollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_RequirementListId",
                table: "Projects",
                newName: "IX_Projects_RequirementICollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_RequirementICollectionId",
                table: "Requirement",
                column: "RequirementICollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_RequirementList_RequirementICollectionId",
                table: "Projects",
                column: "RequirementICollectionId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirement_RequirementList_RequirementICollectionId",
                table: "Requirement",
                column: "RequirementICollectionId",
                principalTable: "RequirementList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
