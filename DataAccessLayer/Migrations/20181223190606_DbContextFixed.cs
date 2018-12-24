using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    public partial class DbContextFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoryPointsSpent",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoryPointsExpected",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScrumTask_StoryPointsSpent",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Tasks",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Boards",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentSprintId",
                table: "Boards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SprintBacklogId",
                table: "BacklogTask",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SprintBacklog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprintBacklog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StoryPointsExpected = table.Column<int>(nullable: false),
                    StoryPointsActual = table.Column<int>(nullable: false),
                    SprintBacklogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sprint_SprintBacklog_SprintBacklogId",
                        column: x => x.SprintBacklogId,
                        principalTable: "SprintBacklog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_SprintId",
                table: "Tasks",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_CurrentSprintId",
                table: "Boards",
                column: "CurrentSprintId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BacklogTask_SprintBacklogId",
                table: "BacklogTask",
                column: "SprintBacklogId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_SprintBacklogId",
                table: "Sprint",
                column: "SprintBacklogId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BacklogTask_SprintBacklog_SprintBacklogId",
                table: "BacklogTask",
                column: "SprintBacklogId",
                principalTable: "SprintBacklog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Sprint_CurrentSprintId",
                table: "Boards",
                column: "CurrentSprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Sprint_SprintId",
                table: "Tasks",
                column: "SprintId",
                principalTable: "Sprint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BacklogTask_SprintBacklog_SprintBacklogId",
                table: "BacklogTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Sprint_CurrentSprintId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Sprint_SprintId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "SprintBacklog");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_SprintId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Boards_CurrentSprintId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_BacklogTask_SprintBacklogId",
                table: "BacklogTask");

            migrationBuilder.DropColumn(
                name: "StoryPointsSpent",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "StoryPointsExpected",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ScrumTask_StoryPointsSpent",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "CurrentSprintId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "SprintBacklogId",
                table: "BacklogTask");
        }
    }
}
