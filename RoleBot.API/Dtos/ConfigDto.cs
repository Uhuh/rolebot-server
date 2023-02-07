namespace Rolebot.API.Dtos;
using ConfigInfraDto = RoleBot.Infrastructure.Dtos.ConfigDto;
using ReactTypeInfra = RoleBot.Infrastructure.Enums.GuildReactType;

public enum GuildReactType
{
    Reaction = 0,
    Button,
    Select
}

public record ConfigDto(
    long Id,
    string GuildId,
    GuildReactType ReactType,
    bool HideEmojis
)
{
    public static ReactTypeInfra TypeTo(GuildReactType type) => type switch
    {
        GuildReactType.Reaction => ReactTypeInfra.Reaction,
        GuildReactType.Button => ReactTypeInfra.Button,
        GuildReactType.Select => ReactTypeInfra.Select,
        _ => ReactTypeInfra.Reaction
    };
    public static ConfigInfraDto To(ConfigDto dto) => new (dto.Id, dto.GuildId, TypeTo(dto.ReactType), dto.HideEmojis);
}