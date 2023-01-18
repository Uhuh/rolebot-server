namespace Rolebot.API.Dtos;

public enum GuildReactType
{
    Reaction = 0,
    Button,
    Select
}

public record ConfigDto(
    string GuildId,
    GuildReactType ReactType,
    bool HideEmojis
);