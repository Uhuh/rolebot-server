using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Dtos;

public record GuildInfoDto(
    string GuildId,
    ICollection<GuildRoleDto> GuildRoles,
    ICollection<GuildEmojiDto> GuildEmojis
)
{
    public static GuildInfoDto From(GuildInfo info) => new (
            info.GuildId,
            info.GuildRoles.Select(GuildRoleDto.From).ToList(), 
            info.GuildEmojis.Select(GuildEmojiDto.From).ToList()
    );
}