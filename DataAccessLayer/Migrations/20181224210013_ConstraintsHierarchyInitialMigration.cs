using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
	public partial class ConstraintsHierarchyInitialMigration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					"ConstraintRecord");

			migrationBuilder.CreateTable(
					"BoardConstraints",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							OwnerId       = table.Column<int>(nullable: false),
							Discriminator = table.Column<string>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_BoardConstraints", x => x.Id);
						table.ForeignKey(
								"FK_BoardConstraints_Boards_OwnerId",
								x => x.OwnerId,
								"Boards",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"ColumnConstraints",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							OwnerId       = table.Column<int>(nullable: false),
							Discriminator = table.Column<string>(nullable: false),
							Quantity      = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ColumnConstraints", x => x.Id);
						table.ForeignKey(
								"FK_ColumnConstraints_Columns_OwnerId",
								x => x.OwnerId,
								"Columns",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"TaskConstraints",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							OwnerId       = table.Column<int>(nullable: false),
							Discriminator = table.Column<string>(nullable: false),
							ParentTaskId  = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_TaskConstraints", x => x.Id);
						table.ForeignKey(
								"FK_TaskConstraints_Tasks_OwnerId",
								x => x.OwnerId,
								"Tasks",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_TaskConstraints_Tasks_ParentTaskId",
								x => x.ParentTaskId,
								"Tasks",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateIndex(
					"IX_BoardConstraints_OwnerId",
					"BoardConstraints",
					"OwnerId");

			migrationBuilder.CreateIndex(
					"IX_ColumnConstraints_OwnerId",
					"ColumnConstraints",
					"OwnerId");

			migrationBuilder.CreateIndex(
					"IX_TaskConstraints_OwnerId",
					"TaskConstraints",
					"OwnerId");

			migrationBuilder.CreateIndex(
					"IX_TaskConstraints_ParentTaskId",
					"TaskConstraints",
					"ParentTaskId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					"BoardConstraints");

			migrationBuilder.DropTable(
					"ColumnConstraints");

			migrationBuilder.DropTable(
					"TaskConstraints");

			migrationBuilder.CreateTable(
					"ConstraintRecord",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							BoardId  = table.Column<int>(nullable: true),
							ColumnId = table.Column<int>(nullable: true),
							Name     = table.Column<string>(maxLength: 255, nullable: false),
							TaskId   = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ConstraintRecord", x => x.Id);
						table.ForeignKey(
								"FK_ConstraintRecord_Boards_BoardId",
								x => x.BoardId,
								"Boards",
								"Id",
								onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
								"FK_ConstraintRecord_Columns_ColumnId",
								x => x.ColumnId,
								"Columns",
								"Id",
								onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
								"FK_ConstraintRecord_Tasks_TaskId",
								x => x.TaskId,
								"Tasks",
								"Id",
								onDelete: ReferentialAction.Restrict);
					});

			migrationBuilder.CreateIndex(
					"IX_ConstraintRecord_BoardId",
					"ConstraintRecord",
					"BoardId");

			migrationBuilder.CreateIndex(
					"IX_ConstraintRecord_ColumnId",
					"ConstraintRecord",
					"ColumnId");

			migrationBuilder.CreateIndex(
					"IX_ConstraintRecord_TaskId",
					"ConstraintRecord",
					"TaskId");
		}
	}
}