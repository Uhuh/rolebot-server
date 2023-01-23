using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Models;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface ICategoryService
{
    public Task<Category?> GetCategory(long categoryId);
    public Task<List<Category>> GetGuildCategories(string guildId);
    public Task<CategoryDto?> UpdateCategory(CategoryDto category);
}