namespace Rolebot.API.Dtos;

public record ReactRoleDto(
    string GuildId,
    string Name,
    string Description,
    string RoleId,
    string EmojiId,
    string? EmojiTag,
    long? CategoryId,
    DateTime? CategoryAddDate
)
{
    public static RoleBot.Infrastructure.Dtos.ReactRoleDto To(ReactRoleDto dto) => new(dto.GuildId, dto.Name, dto.Description,
        dto.RoleId, dto.EmojiId, dto.EmojiTag, dto.CategoryId, dto.CategoryAddDate);
    public static ReactRoleDto From(RoleBot.Infrastructure.Dtos.ReactRoleDto dto) => new(dto.GuildId, dto.Name, dto.Description,
        dto.RoleId, dto.EmojiId, dto.EmojiTag, dto.CategoryId, dto.CategoryAddDate);
}