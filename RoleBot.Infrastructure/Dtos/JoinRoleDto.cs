using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Dtos;

public record JoinRoleDto(string Id, string RoleId, string Name, string GuildId)
{
    public static JoinRoleDto From(JoinRole dto) => new(dto.Id, dto.RoleId, dto.Name, dto.GuildId);
}