using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFollower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFollower",
                columns: table => new
                {
                    UserFollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FollowedUserId = table.Column<string>(type: "text", nullable: false),
                    isFollowing = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollower", x => x.UserFollowerId);
                    table.ForeignKey(
                        name: "FK_UserFollower_AspNetUsers_FollowedUserId",
                        column: x => x.FollowedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollower_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFollower_FollowedUserId",
                table: "UserFollower",
                column: "FollowedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollower_UserId",
                table: "UserFollower",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFollower");
        }
    }
}
