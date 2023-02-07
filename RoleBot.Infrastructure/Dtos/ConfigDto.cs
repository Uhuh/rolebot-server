using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure.Dtos;

public record ConfigDto(
    long Id,
    string GuildId,
    GuildReactType ReactType,
    bool HideEmojis
)
{
    public static ConfigDto From(GuildConfig config) =>
        new(config.Id, config.GuildId, config.ReactType, config.HideEmojis);
}