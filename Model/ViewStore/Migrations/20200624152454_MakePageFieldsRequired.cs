using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.ViewStore.Migrations
{
    public partial class MakePageFieldsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PageData",
                table: "Pages",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PageName",
                table: "Pages",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageData",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageName",
                table: "Pages");
        }
    }
}
