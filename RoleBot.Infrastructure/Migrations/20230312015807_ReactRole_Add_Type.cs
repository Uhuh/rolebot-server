using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBot.Infrastructure.Migrations
{
    public partial class ReactRole_Add_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "react_role",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "react_role");
        }
    }
}
