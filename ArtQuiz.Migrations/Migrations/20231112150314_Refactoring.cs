using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizMarks_AspNetUsers_UserId",
                table: "QuizMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizMarks_Quizzes_QuizId",
                table: "QuizMarks");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTags_Quizzes_QuizId",
                table: "QuizTags");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizTags",
                table: "QuizTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizMarks",
                table: "QuizMarks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageTemplates",
                table: "MessageTemplates");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "QuizTags");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "QuizTags");

            migrationBuilder.RenameTable(
                name: "UserApiKeys",
                newName: "UserApiKey");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quiz");

            migrationBuilder.RenameTable(
                name: "QuizTags",
                newName: "QuizTag");

            migrationBuilder.RenameTable(
                name: "QuizMarks",
                newName: "QuizMark");

            migrationBuilder.RenameTable(
                name: "MessageTemplates",
                newName: "MessageTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_UserApiKeys_UserId",
                table: "UserApiKey",
                newName: "IX_UserApiKey_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_UserId",
                table: "Quiz",
                newName: "IX_Quiz_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizTags_QuizId",
                table: "QuizTag",
                newName: "IX_QuizTag_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizMarks_UserId",
                table: "QuizMark",
                newName: "IX_QuizMark_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizMarks_QuizId",
                table: "QuizMark",
                newName: "IX_QuizMark_QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserApiKey",
                table: "UserApiKey",
                column: "UserApiKeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizTag",
                table: "QuizTag",
                column: "QuizTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizMark",
                table: "QuizMark",
                column: "QuizMarkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageTemplate",
                table: "MessageTemplate",
                column: "MessageTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_AspNetUsers_UserId",
                table: "Quiz",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizMark_AspNetUsers_UserId",
                table: "QuizMark",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizMark_Quiz_QuizId",
                table: "QuizMark",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizTag_Quiz_QuizId",
                table: "QuizTag",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKey_AspNetUsers_UserId",
                table: "UserApiKey",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_AspNetUsers_UserId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizMark_AspNetUsers_UserId",
                table: "QuizMark");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizMark_Quiz_QuizId",
                table: "QuizMark");

            migrationBuilder.DropForeignKey(
                name: "FK_QuizTag_Quiz_QuizId",
                table: "QuizTag");

            migrationBuilder.DropForeignKey(
                name: "FK_UserApiKey_AspNetUsers_UserId",
                table: "UserApiKey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserApiKey",
                table: "UserApiKey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizTag",
                table: "QuizTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuizMark",
                table: "QuizMark");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageTemplate",
                table: "MessageTemplate");

            migrationBuilder.RenameTable(
                name: "UserApiKey",
                newName: "UserApiKeys");

            migrationBuilder.RenameTable(
                name: "QuizTag",
                newName: "QuizTags");

            migrationBuilder.RenameTable(
                name: "QuizMark",
                newName: "QuizMarks");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "Quizzes");

            migrationBuilder.RenameTable(
                name: "MessageTemplate",
                newName: "MessageTemplates");

            migrationBuilder.RenameIndex(
                name: "IX_UserApiKey_UserId",
                table: "UserApiKeys",
                newName: "IX_UserApiKeys_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizTag_QuizId",
                table: "QuizTags",
                newName: "IX_QuizTags_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizMark_UserId",
                table: "QuizMarks",
                newName: "IX_QuizMarks_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_QuizMark_QuizId",
                table: "QuizMarks",
                newName: "IX_QuizMarks_QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_UserId",
                table: "Quizzes",
                newName: "IX_Quizzes_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "QuizTags",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Version",
                table: "QuizTags",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserApiKeys",
                table: "UserApiKeys",
                column: "UserApiKeyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizTags",
                table: "QuizTags",
                column: "QuizTagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuizMarks",
                table: "QuizMarks",
                column: "QuizMarkId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "QuizId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageTemplates",
                table: "MessageTemplates",
                column: "MessageTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizMarks_AspNetUsers_UserId",
                table: "QuizMarks",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizMarks_Quizzes_QuizId",
                table: "QuizMarks",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuizTags_Quizzes_QuizId",
                table: "QuizTags",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_AspNetUsers_UserId",
                table: "Quizzes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApiKeys_AspNetUsers_UserId",
                table: "UserApiKeys",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
