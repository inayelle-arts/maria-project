using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    public partial class EntitiesFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementList_RequirementListId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementList_RequirementListId",
                table: "Requirement");

            migrationBuilder.DropTable(
                name: "RequirementList");

            migrationBuilder.RenameColumn(
                name: "RequirementListId",
                table: "Requirement",
                newName: "RequirementICollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirement_RequirementListId",
                table: "Requirement",
                newName: "IX_Requirement_RequirementICollectionId");

            migrationBuilder.RenameColumn(
                name: "RequirementListId",
                table: "Projects",
                newName: "RequirementICollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_RequirementListId",
                table: "Projects",
                newName: "IX_Projects_RequirementICollectionId");

            migrationBuilder.CreateTable(
                name: "RequirementICollection",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementICollection", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_RequirementICollection_RequirementICollectionId",
                table: "Projects",
                column: "RequirementICollectionId",
                principalTable: "RequirementICollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requirement_RequirementICollection_RequirementICollectionId",
                table: "Requirement",
                column: "RequirementICollectionId",
                principalTable: "RequirementICollection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementICollection_RequirementICollectionId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementICollection_RequirementICollectionId",
                table: "Requirement");

            migrationBuilder.DropTable(
                name: "RequirementICollection");

            migrationBuilder.RenameColumn(
                name: "RequirementICollectionId",
                table: "Requirement",
                newName: "RequirementListId");

            migrationBuilder.RenameIndex(
                name: "IX_Requirement_RequirementICollectionId",
                table: "Requirement",
                newName: "IX_Requirement_RequirementListId");

            migrationBuilder.RenameColumn(
                name: "RequirementICollectionId",
                table: "Projects",
                newName: "RequirementListId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_RequirementICollectionId",
                table: "Projects",
                newName: "IX_Projects_RequirementListId");

            migrationBuilder.CreateTable(
                name: "RequirementList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequirementList", x => x.Id);
                });

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
