using Microsoft.EntityFrameworkCore.Migrations;

namespace TinRoll.Data.Migrations
{
    public partial class ChangingPostRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LatestQuestionPostId",
                table: "Questions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LatestQuestionPostId1",
                table: "Questions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LatestAnswerPostId",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LatestAnswerPostId1",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_LatestQuestionPostId1",
                table: "Questions",
                column: "LatestQuestionPostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_LatestAnswerPostId1",
                table: "Answers",
                column: "LatestAnswerPostId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AnswerPosts_LatestAnswerPostId1",
                table: "Answers",
                column: "LatestAnswerPostId1",
                principalTable: "AnswerPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionPosts_LatestQuestionPostId1",
                table: "Questions",
                column: "LatestQuestionPostId1",
                principalTable: "QuestionPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AnswerPosts_LatestAnswerPostId1",
                table: "Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionPosts_LatestQuestionPostId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_LatestQuestionPostId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Answers_LatestAnswerPostId1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "LatestQuestionPostId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LatestQuestionPostId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "LatestAnswerPostId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "LatestAnswerPostId1",
                table: "Answers");
        }
    }
}
