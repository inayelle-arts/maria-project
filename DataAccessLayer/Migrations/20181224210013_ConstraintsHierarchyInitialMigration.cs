using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
    public partial class ConstraintsHierarchyInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstraintRecord");

            migrationBuilder.CreateTable(
                name: "BoardConstraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardConstraints_Boards_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColumnConstraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColumnConstraints_Columns_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskConstraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OwnerId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ParentTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskConstraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskConstraints_Tasks_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskConstraints_Tasks_ParentTaskId",
                        column: x => x.ParentTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardConstraints_OwnerId",
                table: "BoardConstraints",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ColumnConstraints_OwnerId",
                table: "ColumnConstraints",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskConstraints_OwnerId",
                table: "TaskConstraints",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskConstraints_ParentTaskId",
                table: "TaskConstraints",
                column: "ParentTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardConstraints");

            migrationBuilder.DropTable(
                name: "ColumnConstraints");

            migrationBuilder.DropTable(
                name: "TaskConstraints");

            migrationBuilder.CreateTable(
                name: "ConstraintRecord",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    BoardId = table.Column<int>(nullable: true),
                    ColumnId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstraintRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstraintRecord_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConstraintRecord_Columns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Columns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConstraintRecord_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintRecord_BoardId",
                table: "ConstraintRecord",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintRecord_ColumnId",
                table: "ConstraintRecord",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintRecord_TaskId",
                table: "ConstraintRecord",
                column: "TaskId");
        }
    }
}
