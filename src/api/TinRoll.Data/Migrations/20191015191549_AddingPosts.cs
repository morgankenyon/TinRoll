using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TinRoll.Data.Migrations
{
    public partial class AddingPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Answers");

            migrationBuilder.CreateTable(
                name: "AnswerPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    AnswerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerPosts_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionPosts_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuestionPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnswerPosts_AnswerId",
                table: "AnswerPosts",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerPosts_UserId",
                table: "AnswerPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPosts_QuestionId",
                table: "QuestionPosts",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionPosts_UserId",
                table: "QuestionPosts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerPosts");

            migrationBuilder.DropTable(
                name: "QuestionPosts");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Answers",
                nullable: true);
        }
    }
}
