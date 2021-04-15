using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MailNotification.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "MailTemplate",
                schema: "public",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    IsBodyHtml = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailTemplate", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SentMail",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: false),
                    IsBodyHtml = table.Column<bool>(nullable: false),
                    SentDate = table.Column<DateTime>(nullable: false),
                    MailTemplateName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentMail_MailTemplate_MailTemplateName",
                        column: x => x.MailTemplateName,
                        principalSchema: "public",
                        principalTable: "MailTemplate",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SentMail_MailTemplateName",
                schema: "public",
                table: "SentMail",
                column: "MailTemplateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SentMail",
                schema: "public");

            migrationBuilder.DropTable(
                name: "MailTemplate",
                schema: "public");
        }
    }
}
