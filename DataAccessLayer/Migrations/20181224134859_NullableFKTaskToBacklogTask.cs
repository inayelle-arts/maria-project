using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccessLayer.Migrations
{
	public partial class NullableFKTaskToBacklogTask : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
					"Attachment",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							StoragePath = table.Column<string>(nullable: true)
					},
					constraints: table => { table.PrimaryKey("PK_Attachment", x => x.Id); });

			migrationBuilder.CreateTable(
					"Companies",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Description = table.Column<string>(nullable: true),
							Email       = table.Column<string>(nullable: false),
							Name        = table.Column<string>(maxLength: 255, nullable: false)
					},
					constraints: table => { table.PrimaryKey("PK_Companies", x => x.Id); });

			migrationBuilder.CreateTable(
					"History",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn)
					},
					constraints: table => { table.PrimaryKey("PK_History", x => x.Id); });

			migrationBuilder.CreateTable(
					"ProjectBacklog",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn)
					},
					constraints: table => { table.PrimaryKey("PK_ProjectBacklog", x => x.Id); });

			migrationBuilder.CreateTable(
					"RequirementList",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn)
					},
					constraints: table => { table.PrimaryKey("PK_RequirementList", x => x.Id); });

			migrationBuilder.CreateTable(
					"SprintBacklog",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn)
					},
					constraints: table => { table.PrimaryKey("PK_SprintBacklog", x => x.Id); });

			migrationBuilder.CreateTable(
					"Users",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Email        = table.Column<string>(nullable: false),
							Fullname     = table.Column<string>(maxLength: 255, nullable: false),
							PasswordHash = table.Column<string>(nullable: true)
					},
					constraints: table => { table.PrimaryKey("PK_Users", x => x.Id); });

			migrationBuilder.CreateTable(
					"HistoryPoint",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Date      = table.Column<DateTime>(nullable: false),
							Event     = table.Column<string>(nullable: false),
							HistoryId = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_HistoryPoint", x => x.Id);
						table.ForeignKey(
								"FK_HistoryPoint_History_HistoryId",
								x => x.HistoryId,
								"History",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Requirement",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name              = table.Column<string>(maxLength: 255, nullable: false),
							Description       = table.Column<string>(nullable: true),
							Priority          = table.Column<int>(nullable: false),
							RequirementListId = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Requirement", x => x.Id);
						table.ForeignKey(
								"FK_Requirement_RequirementList_RequirementListId",
								x => x.RequirementListId,
								"RequirementList",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Sprint",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							CreationDate        = table.Column<DateTime>(nullable: false),
							StoryPointsExpected = table.Column<int>(nullable: false),
							StoryPointsActual   = table.Column<int>(nullable: false),
							SprintBacklogId     = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Sprint", x => x.Id);
						table.ForeignKey(
								"FK_Sprint_SprintBacklog_SprintBacklogId",
								x => x.SprintBacklogId,
								"SprintBacklog",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"ContactInfo",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Identifier = table.Column<string>(nullable: false),
							Source     = table.Column<string>(nullable: false),
							OwnerId    = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_ContactInfo", x => x.Id);
						table.ForeignKey(
								"FK_ContactInfo_Users_OwnerId",
								x => x.OwnerId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Restrict);
					});

			migrationBuilder.CreateTable(
					"Cooperation",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							StartOfCooperation = table.Column<DateTime>(nullable: false),
							EndOfCooperation   = table.Column<DateTime>(nullable: false),
							CompanyId          = table.Column<int>(nullable: false),
							MemberId           = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Cooperation", x => x.Id);
						table.ForeignKey(
								"FK_Cooperation_Companies_CompanyId",
								x => x.CompanyId,
								"Companies",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Cooperation_Users_MemberId",
								x => x.MemberId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Projects",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name              = table.Column<string>(maxLength: 255, nullable: false),
							Description       = table.Column<string>(nullable: false),
							ProjectRootId     = table.Column<int>(nullable: false),
							RequirementListId = table.Column<int>(nullable: false),
							BacklogId         = table.Column<int>(nullable: false),
							CompanyId         = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Projects", x => x.Id);
						table.ForeignKey(
								"FK_Projects_ProjectBacklog_BacklogId",
								x => x.BacklogId,
								"ProjectBacklog",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Projects_Companies_CompanyId",
								x => x.CompanyId,
								"Companies",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Projects_Users_ProjectRootId",
								x => x.ProjectRootId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Projects_RequirementList_RequirementListId",
								x => x.RequirementListId,
								"RequirementList",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"BacklogTask",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name             = table.Column<string>(maxLength: 255, nullable: false),
							Description      = table.Column<string>(nullable: true),
							Priority         = table.Column<int>(nullable: false),
							RequirementId    = table.Column<int>(nullable: false),
							ProjectBacklogId = table.Column<int>(nullable: true),
							SprintBacklogId  = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_BacklogTask", x => x.Id);
						table.ForeignKey(
								"FK_BacklogTask_ProjectBacklog_ProjectBacklogId",
								x => x.ProjectBacklogId,
								"ProjectBacklog",
								"Id",
								onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
								"FK_BacklogTask_Requirement_RequirementId",
								x => x.RequirementId,
								"Requirement",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_BacklogTask_SprintBacklog_SprintBacklogId",
								x => x.SprintBacklogId,
								"SprintBacklog",
								"Id",
								onDelete: ReferentialAction.Restrict);
					});

			migrationBuilder.CreateTable(
					"Teams",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name      = table.Column<string>(maxLength: 255, nullable: false),
							CompanyId = table.Column<int>(nullable: false),
							ProjectId = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Teams", x => x.Id);
						table.ForeignKey(
								"FK_Teams_Companies_CompanyId",
								x => x.CompanyId,
								"Companies",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Teams_Projects_ProjectId",
								x => x.ProjectId,
								"Projects",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Boards",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name            = table.Column<string>(maxLength: 255, nullable: false),
							TeamId          = table.Column<int>(nullable: false),
							Discriminator   = table.Column<string>(nullable: false),
							CurrentSprintId = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Boards", x => x.Id);
						table.ForeignKey(
								"FK_Boards_Teams_TeamId",
								x => x.TeamId,
								"Teams",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Boards_Sprint_CurrentSprintId",
								x => x.CurrentSprintId,
								"Sprint",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Teams2Users",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							MemberId = table.Column<int>(nullable: false),
							TeamId   = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Teams2Users", x => x.Id);
						table.ForeignKey(
								"FK_Teams2Users_Users_MemberId",
								x => x.MemberId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Teams2Users_Teams_TeamId",
								x => x.TeamId,
								"Teams",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Columns",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name    = table.Column<string>(maxLength: 255, nullable: false),
							BoardId = table.Column<int>(nullable: false)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Columns", x => x.Id);
						table.ForeignKey(
								"FK_Columns_Boards_BoardId",
								x => x.BoardId,
								"Boards",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Tasks",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name                       = table.Column<string>(maxLength: 255, nullable: false),
							Description                = table.Column<string>(nullable: true),
							Code                       = table.Column<string>(nullable: false),
							AssigneeId                 = table.Column<int>(nullable: false),
							ColumnId                   = table.Column<int>(nullable: false),
							BacklogTaskId              = table.Column<int>(nullable: true),
							HistoryId                  = table.Column<int>(nullable: false),
							Discriminator              = table.Column<string>(nullable: false),
							StoryPointsSpent           = table.Column<int>(nullable: true),
							ExpirationDate             = table.Column<DateTime>(nullable: true),
							StoryPointsExpected        = table.Column<int>(nullable: true),
							ScrumTask_StoryPointsSpent = table.Column<int>(nullable: true),
							SprintId                   = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Tasks", x => x.Id);
						table.ForeignKey(
								"FK_Tasks_Sprint_SprintId",
								x => x.SprintId,
								"Sprint",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Tasks_Users_AssigneeId",
								x => x.AssigneeId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Tasks_BacklogTask_BacklogTaskId",
								x => x.BacklogTaskId,
								"BacklogTask",
								"Id",
								onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
								"FK_Tasks_Columns_ColumnId",
								x => x.ColumnId,
								"Columns",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Tasks_History_HistoryId",
								x => x.HistoryId,
								"History",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"Comment",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							CreationDate  = table.Column<DateTime>(nullable: false),
							Text          = table.Column<string>(nullable: true),
							TaskId        = table.Column<int>(nullable: false),
							AuthorId      = table.Column<int>(nullable: false),
							AttachmentsId = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Comment", x => x.Id);
						table.ForeignKey(
								"FK_Comment_Attachment_AttachmentsId",
								x => x.AttachmentsId,
								"Attachment",
								"Id",
								onDelete: ReferentialAction.Restrict);
						table.ForeignKey(
								"FK_Comment_Users_AuthorId",
								x => x.AuthorId,
								"Users",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Comment_Tasks_TaskId",
								x => x.TaskId,
								"Tasks",
								"Id",
								onDelete: ReferentialAction.Cascade);
					});

			migrationBuilder.CreateTable(
					"ConstraintRecord",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							TaskId   = table.Column<int>(nullable: true),
							Name     = table.Column<string>(maxLength: 255, nullable: false),
							BoardId  = table.Column<int>(nullable: true),
							ColumnId = table.Column<int>(nullable: true)
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

			migrationBuilder.CreateTable(
					"Label",
					table => new
					{
							Id = table.Column<int>(nullable: false)
							          .Annotation("Npgsql:ValueGenerationStrategy",
									          NpgsqlValueGenerationStrategy.SerialColumn),
							Name    = table.Column<string>(maxLength: 255, nullable: true),
							BoardId = table.Column<int>(nullable: false),
							TaskId  = table.Column<int>(nullable: true)
					},
					constraints: table =>
					{
						table.PrimaryKey("PK_Label", x => x.Id);
						table.ForeignKey(
								"FK_Label_Boards_BoardId",
								x => x.BoardId,
								"Boards",
								"Id",
								onDelete: ReferentialAction.Cascade);
						table.ForeignKey(
								"FK_Label_Tasks_TaskId",
								x => x.TaskId,
								"Tasks",
								"Id",
								onDelete: ReferentialAction.Restrict);
					});

			migrationBuilder.CreateIndex(
					"IX_BacklogTask_ProjectBacklogId",
					"BacklogTask",
					"ProjectBacklogId");

			migrationBuilder.CreateIndex(
					"IX_BacklogTask_RequirementId",
					"BacklogTask",
					"RequirementId");

			migrationBuilder.CreateIndex(
					"IX_BacklogTask_SprintBacklogId",
					"BacklogTask",
					"SprintBacklogId");

			migrationBuilder.CreateIndex(
					"IX_Boards_TeamId",
					"Boards",
					"TeamId");

			migrationBuilder.CreateIndex(
					"IX_Boards_CurrentSprintId",
					"Boards",
					"CurrentSprintId",
					unique: true);

			migrationBuilder.CreateIndex(
					"IX_Columns_BoardId",
					"Columns",
					"BoardId");

			migrationBuilder.CreateIndex(
					"IX_Comment_AttachmentsId",
					"Comment",
					"AttachmentsId");

			migrationBuilder.CreateIndex(
					"IX_Comment_AuthorId",
					"Comment",
					"AuthorId");

			migrationBuilder.CreateIndex(
					"IX_Comment_TaskId",
					"Comment",
					"TaskId");

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

			migrationBuilder.CreateIndex(
					"IX_ContactInfo_OwnerId",
					"ContactInfo",
					"OwnerId");

			migrationBuilder.CreateIndex(
					"IX_Cooperation_CompanyId",
					"Cooperation",
					"CompanyId");

			migrationBuilder.CreateIndex(
					"IX_Cooperation_MemberId",
					"Cooperation",
					"MemberId");

			migrationBuilder.CreateIndex(
					"IX_HistoryPoint_HistoryId",
					"HistoryPoint",
					"HistoryId");

			migrationBuilder.CreateIndex(
					"IX_Label_BoardId",
					"Label",
					"BoardId");

			migrationBuilder.CreateIndex(
					"IX_Label_TaskId",
					"Label",
					"TaskId");

			migrationBuilder.CreateIndex(
					"IX_Projects_BacklogId",
					"Projects",
					"BacklogId",
					unique: true);

			migrationBuilder.CreateIndex(
					"IX_Projects_CompanyId",
					"Projects",
					"CompanyId");

			migrationBuilder.CreateIndex(
					"IX_Projects_ProjectRootId",
					"Projects",
					"ProjectRootId");

			migrationBuilder.CreateIndex(
					"IX_Projects_RequirementListId",
					"Projects",
					"RequirementListId",
					unique: true);

			migrationBuilder.CreateIndex(
					"IX_Requirement_RequirementListId",
					"Requirement",
					"RequirementListId");

			migrationBuilder.CreateIndex(
					"IX_Sprint_SprintBacklogId",
					"Sprint",
					"SprintBacklogId",
					unique: true);

			migrationBuilder.CreateIndex(
					"IX_Tasks_SprintId",
					"Tasks",
					"SprintId");

			migrationBuilder.CreateIndex(
					"IX_Tasks_AssigneeId",
					"Tasks",
					"AssigneeId");

			migrationBuilder.CreateIndex(
					"IX_Tasks_BacklogTaskId",
					"Tasks",
					"BacklogTaskId");

			migrationBuilder.CreateIndex(
					"IX_Tasks_ColumnId",
					"Tasks",
					"ColumnId");

			migrationBuilder.CreateIndex(
					"IX_Tasks_HistoryId",
					"Tasks",
					"HistoryId");

			migrationBuilder.CreateIndex(
					"IX_Teams_CompanyId",
					"Teams",
					"CompanyId");

			migrationBuilder.CreateIndex(
					"IX_Teams_ProjectId",
					"Teams",
					"ProjectId");

			migrationBuilder.CreateIndex(
					"IX_Teams2Users_MemberId",
					"Teams2Users",
					"MemberId");

			migrationBuilder.CreateIndex(
					"IX_Teams2Users_TeamId",
					"Teams2Users",
					"TeamId");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
					"Comment");

			migrationBuilder.DropTable(
					"ConstraintRecord");

			migrationBuilder.DropTable(
					"ContactInfo");

			migrationBuilder.DropTable(
					"Cooperation");

			migrationBuilder.DropTable(
					"HistoryPoint");

			migrationBuilder.DropTable(
					"Label");

			migrationBuilder.DropTable(
					"Teams2Users");

			migrationBuilder.DropTable(
					"Attachment");

			migrationBuilder.DropTable(
					"Tasks");

			migrationBuilder.DropTable(
					"BacklogTask");

			migrationBuilder.DropTable(
					"Columns");

			migrationBuilder.DropTable(
					"History");

			migrationBuilder.DropTable(
					"Requirement");

			migrationBuilder.DropTable(
					"Boards");

			migrationBuilder.DropTable(
					"Teams");

			migrationBuilder.DropTable(
					"Sprint");

			migrationBuilder.DropTable(
					"Projects");

			migrationBuilder.DropTable(
					"SprintBacklog");

			migrationBuilder.DropTable(
					"ProjectBacklog");

			migrationBuilder.DropTable(
					"Companies");

			migrationBuilder.DropTable(
					"Users");

			migrationBuilder.DropTable(
					"RequirementList");
		}
	}
}