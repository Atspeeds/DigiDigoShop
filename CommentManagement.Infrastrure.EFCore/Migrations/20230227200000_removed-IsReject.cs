using Microsoft.EntityFrameworkCore.Migrations;

namespace CommentManagement.Infrastrure.EFCore.Migrations
{
    public partial class removedIsReject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReJection",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReJection",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
