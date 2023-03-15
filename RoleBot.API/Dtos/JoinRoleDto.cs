namespace Rolebot.API.Dtos;

public record JoinRoleDto(string Id, string RoleId, string GuildId, string Name)
{
    public static JoinRoleDto From(RoleBot.Infrastructure.Dtos.JoinRoleDto dto) => 
        new(dto.Id, dto.RoleId, dto.GuildId, dto.Name);

    public static RoleBot.Infrastructure.Dtos.JoinRoleDto To(JoinRoleDto dto) => 
        new(dto.Id, dto.RoleId,dto.Name,dto.GuildId);
}