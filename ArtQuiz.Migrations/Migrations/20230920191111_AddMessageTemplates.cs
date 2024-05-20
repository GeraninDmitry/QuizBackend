using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtQuiz.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class AddMessageTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageTemplates",
                columns: table => new
                {
                    MessageTemplateId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageType = table.Column<int>(type: "integer", nullable: false),
                    LanguageType = table.Column<int>(type: "integer", nullable: false),
                    EmailType = table.Column<int>(type: "integer", nullable: false),
                    ApplicationType = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTemplates", x => x.MessageTemplateId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageTemplates");
        }
    }
}
