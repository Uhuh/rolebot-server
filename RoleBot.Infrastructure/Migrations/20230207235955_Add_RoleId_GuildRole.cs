using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBot.Infrastructure.Migrations
{
    public partial class Add_RoleId_GuildRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "permissions",
                table: "guild_role",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "roleId",
                table: "guild_role",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roleId",
                table: "guild_role");

            migrationBuilder.AlterColumn<string>(
                name: "permissions",
                table: "guild_role",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
