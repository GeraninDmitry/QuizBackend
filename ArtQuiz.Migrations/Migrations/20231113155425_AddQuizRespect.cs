using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizRespect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizRespect",
                columns: table => new
                {
                    QuizRespectId = table.Column<Guid>(type: "uuid", nullable: false),
                    QuizId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsLiked = table.Column<bool>(type: "boolean", nullable: false),
                    IsDisliked = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizRespect", x => x.QuizRespectId);
                    table.ForeignKey(
                        name: "FK_QuizRespect_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizRespect_Quiz_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quiz",
                        principalColumn: "QuizId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizRespect_QuizId",
                table: "QuizRespect",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizRespect_UserId",
                table: "QuizRespect",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizRespect");
        }
    }
}
