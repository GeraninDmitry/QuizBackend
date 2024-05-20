using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFollower2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFollowing",
                table: "UserFollower",
                newName: "IsFollowing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFollowing",
                table: "UserFollower",
                newName: "isFollowing");
        }
    }
}
