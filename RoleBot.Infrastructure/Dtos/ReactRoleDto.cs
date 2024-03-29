using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Dtos;

public record ReactRoleDto(
    string GuildId,
    string Name,
    string? Description,
    string RoleId,
    string EmojiId,
    string? EmojiTag,
    long? CategoryId,
    DateTime? CategoryAddDate
)
{
    public static ReactRoleDto From(ReactRole rr) => new(rr.GuildId, rr.Name, rr.Description, rr.RoleId, rr.EmojiId, rr.EmojiTag,
        rr.CategoryId, rr.CategoryAddDate);
}