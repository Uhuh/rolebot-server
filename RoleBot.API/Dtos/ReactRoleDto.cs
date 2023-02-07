namespace Rolebot.API.Dtos;

public record ReactRoleDto(
    string GuildId,
    string Name,
    string RoleId,
    string EmojiId,
    string? EmojiTag,
    long? CategoryId,
    DateTime CategoryAddDate
)
{
    public static ReactRoleDto From(RoleBot.Infrastructure.Dtos.ReactRoleDto dto) => new(dto.GuildId, dto.Name,
        dto.RoleId, dto.EmojiId, dto.EmojiTag, dto.CategoryId, dto.CategoryAddDate);
}