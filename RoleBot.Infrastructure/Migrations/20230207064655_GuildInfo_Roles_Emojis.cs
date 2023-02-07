using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RoleBot.Infrastructure.Migrations
{
    public partial class GuildInfo_Roles_Emojis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guild_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guildId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild_info", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "guild_emoji",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guildId = table.Column<string>(type: "text", nullable: false),
                    emojiId = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    GuildInfoId1 = table.Column<long>(type: "bigint", nullable: false),
                    GuildInfoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild_emoji", x => x.id);
                    table.ForeignKey(
                        name: "FK_guild_emoji_guild_info_GuildInfoId",
                        column: x => x.GuildInfoId,
                        principalTable: "guild_info",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_guild_emoji_guild_info_GuildInfoId1",
                        column: x => x.GuildInfoId1,
                        principalTable: "guild_info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "guild_role",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    guildId = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<long>(type: "bigint", nullable: false),
                    position = table.Column<long>(type: "bigint", nullable: false),
                    permissions = table.Column<string>(type: "text", nullable: false),
                    GuildInfoId1 = table.Column<long>(type: "bigint", nullable: false),
                    GuildInfoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guild_role", x => x.id);
                    table.ForeignKey(
                        name: "FK_guild_role_guild_info_GuildInfoId",
                        column: x => x.GuildInfoId,
                        principalTable: "guild_info",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_guild_role_guild_info_GuildInfoId1",
                        column: x => x.GuildInfoId1,
                        principalTable: "guild_info",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guild_emoji_GuildInfoId",
                table: "guild_emoji",
                column: "GuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_guild_emoji_GuildInfoId1",
                table: "guild_emoji",
                column: "GuildInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_guild_role_GuildInfoId",
                table: "guild_role",
                column: "GuildInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_guild_role_GuildInfoId1",
                table: "guild_role",
                column: "GuildInfoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guild_emoji");

            migrationBuilder.DropTable(
                name: "guild_role");

            migrationBuilder.DropTable(
                name: "guild_info");
        }
    }
}
