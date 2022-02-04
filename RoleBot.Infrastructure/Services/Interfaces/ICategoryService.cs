using RoleBot.Infrastructure.Entities;
namespace RoleBot.Infrastructure.Services.Interfaces;

public interface ICategoryService
{
    public Task<Category?> GetCategory(long categoryId);
    public Task<List<Category>> GetGuildCategories(string guildId);
}