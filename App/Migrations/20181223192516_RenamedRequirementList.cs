using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace App.Migrations
{
    public partial class RenamedRequirementList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementICollection_RequirementICollectionId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementICollection_RequirementICollectionId",
                table: "Requirement");

            migrationBuilder.DropTable(
                name: "RequirementICollection");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_RequirementList_RequirementICollectionId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Requirement_RequirementList_RequirementICollectionId",
                table: "Requirement");

            migrationBuilder.DropTable(
                name: "RequirementList");

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
    }
}
