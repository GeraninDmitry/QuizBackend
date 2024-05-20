using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddAdSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdSetting",
                columns: table => new
                {
                    AdSettingId = table.Column<Guid>(type: "uuid", nullable: false),
                    Probability = table.Column<int>(type: "integer", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdSetting", x => x.AdSettingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdSetting");
        }
    }
}
