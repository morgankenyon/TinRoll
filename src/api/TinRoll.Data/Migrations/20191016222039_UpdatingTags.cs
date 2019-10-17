using Microsoft.EntityFrameworkCore.Migrations;

namespace TinRoll.Data.Migrations
{
    public partial class UpdatingTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayText",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "SearchText",
                table: "Tags",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tags",
                newName: "SearchText");

            migrationBuilder.AddColumn<string>(
                name: "DisplayText",
                table: "Tags",
                nullable: true);
        }
    }
}
