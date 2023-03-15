using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Repositories.Interfaces;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

internal class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;

    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }
    public Task<List<ReactRoleDto>> GetGuildRoles(string guildId)
    {
        return _repository.GetGuildRoles(guildId);
    }

    public Task<ReactRoleDto> CreateReactRole(ReactRoleDto reactRole, string guildId)
    {
        return _repository.CreateReactRole(reactRole, guildId);
    }
    public Task<List<JoinRoleDto>> GetGuildJoinRoles(string guildId)
    {
        return _repository.GetGuildJoinRoles(guildId);
    }
    public Task<JoinRoleDto> CreateJoinRole(JoinRoleDto joinRole, string guildId)
    {
        return _repository.CreateJoinRole(joinRole, guildId);
    }
}