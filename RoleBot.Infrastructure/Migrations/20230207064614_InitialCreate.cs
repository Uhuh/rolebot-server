using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RoleBot.Infrastructure.Enums;

#nullable disable

namespace RoleBot.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:category_displayorder_enum", "0,1,2,3")
                .Annotation("Npgsql:Enum:guild_config_reacttype_enum", "0,1,2");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guildId = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    mutuallyExclusive = table.Column<bool>(type: "boolean", nullable: false),
                    displayOrder = table.Column<DisplayOrder>(type: "category_displayorder_enum", nullable: false),
                    requiredRoleId = table.Column<string>(type: "text", nullable: true),
                    excludedRoleId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guild_config",
                columns: table => new
                {
                    guildId = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    reactType = table.Column<GuildReactType>(type: "guild_config_reacttype_enum", nullable: false),
                    hideEmojis = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild_config", x => x.guildId);
                });

            migrationBuilder.CreateTable(
                name: "react_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    guildId = table.Column<string>(type: "text", nullable: false),
                    emojiId = table.Column<string>(type: "text", nullable: false),
                    emojiTag = table.Column<string>(type: "text", nullable: true),
                    categoryId = table.Column<long>(type: "bigint", nullable: true),
                    categoryAddDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_react_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_react_role_category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_react_role_categoryId",
                table: "react_role",
                column: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guild_config");

            migrationBuilder.DropTable(
                name: "react_role");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
