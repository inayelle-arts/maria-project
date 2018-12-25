using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
	public partial class migrationAfterKurenie : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Comment_Attachment_AttachmentsId",
					"Comment");

			migrationBuilder.DropForeignKey(
					"FK_Comment_Users_AuthorId",
					"Comment");

			migrationBuilder.DropForeignKey(
					"FK_Comment_Tasks_TaskId",
					"Comment");

			migrationBuilder.DropForeignKey(
					"FK_Label_Boards_BoardId",
					"Label");

			migrationBuilder.DropForeignKey(
					"FK_Label_Tasks_TaskId",
					"Label");

			migrationBuilder.DropForeignKey(
					"FK_Teams_Boards_BoardId",
					"Teams");

			migrationBuilder.DropIndex(
					"IX_Teams_BoardId",
					"Teams");

			migrationBuilder.DropPrimaryKey(
					"PK_Label",
					"Label");

			migrationBuilder.DropPrimaryKey(
					"PK_Comment",
					"Comment");

			migrationBuilder.DropColumn(
					"BoardId",
					"Teams");

			migrationBuilder.RenameTable(
					"Label",
					newName: "Labels");

			migrationBuilder.RenameTable(
					"Comment",
					newName: "Comments");

			migrationBuilder.RenameIndex(
					"IX_Label_TaskId",
					table: "Labels",
					newName: "IX_Labels_TaskId");

			migrationBuilder.RenameIndex(
					"IX_Label_BoardId",
					table: "Labels",
					newName: "IX_Labels_BoardId");

			migrationBuilder.RenameIndex(
					"IX_Comment_TaskId",
					table: "Comments",
					newName: "IX_Comments_TaskId");

			migrationBuilder.RenameIndex(
					"IX_Comment_AuthorId",
					table: "Comments",
					newName: "IX_Comments_AuthorId");

			migrationBuilder.RenameIndex(
					"IX_Comment_AttachmentsId",
					table: "Comments",
					newName: "IX_Comments_AttachmentsId");

			migrationBuilder.AddColumn<int>(
					"HistoryId",
					"Columns",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddColumn<int>(
					"HistoryId",
					"Boards",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddColumn<int>(
					"TeamId",
					"Boards",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
					"PK_Labels",
					"Labels",
					"Id");

			migrationBuilder.AddPrimaryKey(
					"PK_Comments",
					"Comments",
					"Id");

			migrationBuilder.CreateIndex(
					"IX_Columns_HistoryId",
					"Columns",
					"HistoryId");

			migrationBuilder.CreateIndex(
					"IX_Boards_HistoryId",
					"Boards",
					"HistoryId");

			migrationBuilder.CreateIndex(
					"IX_Boards_TeamId",
					"Boards",
					"TeamId",
					unique: true);

			migrationBuilder.AddForeignKey(
					"FK_Boards_Histories_HistoryId",
					"Boards",
					"HistoryId",
					"Histories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Boards_Teams_TeamId",
					"Boards",
					"TeamId",
					"Teams",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Columns_Histories_HistoryId",
					"Columns",
					"HistoryId",
					"Histories",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Comments_Attachment_AttachmentsId",
					"Comments",
					"AttachmentsId",
					"Attachment",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
					"FK_Comments_Users_AuthorId",
					"Comments",
					"AuthorId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Comments_Tasks_TaskId",
					"Comments",
					"TaskId",
					"Tasks",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Labels_Boards_BoardId",
					"Labels",
					"BoardId",
					"Boards",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Labels_Tasks_TaskId",
					"Labels",
					"TaskId",
					"Tasks",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(
					"FK_Boards_Histories_HistoryId",
					"Boards");

			migrationBuilder.DropForeignKey(
					"FK_Boards_Teams_TeamId",
					"Boards");

			migrationBuilder.DropForeignKey(
					"FK_Columns_Histories_HistoryId",
					"Columns");

			migrationBuilder.DropForeignKey(
					"FK_Comments_Attachment_AttachmentsId",
					"Comments");

			migrationBuilder.DropForeignKey(
					"FK_Comments_Users_AuthorId",
					"Comments");

			migrationBuilder.DropForeignKey(
					"FK_Comments_Tasks_TaskId",
					"Comments");

			migrationBuilder.DropForeignKey(
					"FK_Labels_Boards_BoardId",
					"Labels");

			migrationBuilder.DropForeignKey(
					"FK_Labels_Tasks_TaskId",
					"Labels");

			migrationBuilder.DropIndex(
					"IX_Columns_HistoryId",
					"Columns");

			migrationBuilder.DropIndex(
					"IX_Boards_HistoryId",
					"Boards");

			migrationBuilder.DropIndex(
					"IX_Boards_TeamId",
					"Boards");

			migrationBuilder.DropPrimaryKey(
					"PK_Labels",
					"Labels");

			migrationBuilder.DropPrimaryKey(
					"PK_Comments",
					"Comments");

			migrationBuilder.DropColumn(
					"HistoryId",
					"Columns");

			migrationBuilder.DropColumn(
					"HistoryId",
					"Boards");

			migrationBuilder.DropColumn(
					"TeamId",
					"Boards");

			migrationBuilder.RenameTable(
					"Labels",
					newName: "Label");

			migrationBuilder.RenameTable(
					"Comments",
					newName: "Comment");

			migrationBuilder.RenameIndex(
					"IX_Labels_TaskId",
					table: "Label",
					newName: "IX_Label_TaskId");

			migrationBuilder.RenameIndex(
					"IX_Labels_BoardId",
					table: "Label",
					newName: "IX_Label_BoardId");

			migrationBuilder.RenameIndex(
					"IX_Comments_TaskId",
					table: "Comment",
					newName: "IX_Comment_TaskId");

			migrationBuilder.RenameIndex(
					"IX_Comments_AuthorId",
					table: "Comment",
					newName: "IX_Comment_AuthorId");

			migrationBuilder.RenameIndex(
					"IX_Comments_AttachmentsId",
					table: "Comment",
					newName: "IX_Comment_AttachmentsId");

			migrationBuilder.AddColumn<int>(
					"BoardId",
					"Teams",
					nullable: false,
					defaultValue: 0);

			migrationBuilder.AddPrimaryKey(
					"PK_Label",
					"Label",
					"Id");

			migrationBuilder.AddPrimaryKey(
					"PK_Comment",
					"Comment",
					"Id");

			migrationBuilder.CreateIndex(
					"IX_Teams_BoardId",
					"Teams",
					"BoardId",
					unique: true);

			migrationBuilder.AddForeignKey(
					"FK_Comment_Attachment_AttachmentsId",
					"Comment",
					"AttachmentsId",
					"Attachment",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
					"FK_Comment_Users_AuthorId",
					"Comment",
					"AuthorId",
					"Users",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Comment_Tasks_TaskId",
					"Comment",
					"TaskId",
					"Tasks",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Label_Boards_BoardId",
					"Label",
					"BoardId",
					"Boards",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);

			migrationBuilder.AddForeignKey(
					"FK_Label_Tasks_TaskId",
					"Label",
					"TaskId",
					"Tasks",
					principalColumn: "Id",
					onDelete: ReferentialAction.Restrict);

			migrationBuilder.AddForeignKey(
					"FK_Teams_Boards_BoardId",
					"Teams",
					"BoardId",
					"Boards",
					principalColumn: "Id",
					onDelete: ReferentialAction.Cascade);
		}
	}
}