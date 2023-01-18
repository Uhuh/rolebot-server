namespace Rolebot.API.Dtos;

public record ReactRoleDto(
    string GuildId,
    string Name,
    string RoleId,
    string EmojiId,
    string EmojiTag,
    int? CategoryId,
    DateTime CategoryAddDate
);