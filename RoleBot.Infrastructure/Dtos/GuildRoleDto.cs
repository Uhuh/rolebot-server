using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Dtos;

public record GuildRoleDto(
    string GuildId,
    string RoleId,
    string Name,
    long Color,
    long Position,
    long Permissions
)
{
    public static GuildRoleDto From(GuildRole role) =>
        new(role.GuildId, role.RoleId, role.Name, role.Color, role.Position, role.Permissions);
}