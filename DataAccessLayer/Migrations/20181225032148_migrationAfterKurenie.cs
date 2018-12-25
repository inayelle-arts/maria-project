using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class migrationAfterKurenie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Attachment_AttachmentsId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Users_AuthorId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Tasks_TaskId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Label_Boards_BoardId",
                table: "Label");

            migrationBuilder.DropForeignKey(
                name: "FK_Label_Tasks_TaskId",
                table: "Label");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Boards_BoardId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_BoardId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Label",
                table: "Label");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "BoardId",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Label",
                newName: "Labels");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Label_TaskId",
                table: "Labels",
                newName: "IX_Labels_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Label_BoardId",
                table: "Labels",
                newName: "IX_Labels_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TaskId",
                table: "Comments",
                newName: "IX_Comments_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AuthorId",
                table: "Comments",
                newName: "IX_Comments_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_AttachmentsId",
                table: "Comments",
                newName: "IX_Comments_AttachmentsId");

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Columns",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Boards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Labels",
                table: "Labels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Columns_HistoryId",
                table: "Columns",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_HistoryId",
                table: "Boards",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Boards_TeamId",
                table: "Boards",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Histories_HistoryId",
                table: "Boards",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Histories_HistoryId",
                table: "Columns",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Attachment_AttachmentsId",
                table: "Comments",
                column: "AttachmentsId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Boards_BoardId",
                table: "Labels",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Labels_Tasks_TaskId",
                table: "Labels",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Histories_HistoryId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Teams_TeamId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Histories_HistoryId",
                table: "Columns");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Attachment_AttachmentsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_AuthorId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Tasks_TaskId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Boards_BoardId",
                table: "Labels");

            migrationBuilder.DropForeignKey(
                name: "FK_Labels_Tasks_TaskId",
                table: "Labels");

            migrationBuilder.DropIndex(
                name: "IX_Columns_HistoryId",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Boards_HistoryId",
                table: "Boards");

            migrationBuilder.DropIndex(
                name: "IX_Boards_TeamId",
                table: "Boards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Labels",
                table: "Labels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Boards");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Boards");

            migrationBuilder.RenameTable(
                name: "Labels",
                newName: "Label");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_TaskId",
                table: "Label",
                newName: "IX_Label_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Labels_BoardId",
                table: "Label",
                newName: "IX_Label_BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TaskId",
                table: "Comment",
                newName: "IX_Comment_TaskId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AuthorId",
                table: "Comment",
                newName: "IX_Comment_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_AttachmentsId",
                table: "Comment",
                newName: "IX_Comment_AttachmentsId");

            migrationBuilder.AddColumn<int>(
                name: "BoardId",
                table: "Teams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Label",
                table: "Label",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_BoardId",
                table: "Teams",
                column: "BoardId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Attachment_AttachmentsId",
                table: "Comment",
                column: "AttachmentsId",
                principalTable: "Attachment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Users_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Tasks_TaskId",
                table: "Comment",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Boards_BoardId",
                table: "Label",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Label_Tasks_TaskId",
                table: "Label",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Boards_BoardId",
                table: "Teams",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
