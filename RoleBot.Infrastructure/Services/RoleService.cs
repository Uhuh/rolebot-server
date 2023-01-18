using RoleBot.Infrastructure.Entities;
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
    public Task<List<ReactRole>?> GetGuildRoles(string reactRoleId)
    {
        return null;
    }
}