using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBot.Infrastructure.Migrations
{
    public partial class ReactRole_Add_Description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "react_role",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "react_role");
        }
    }
}
