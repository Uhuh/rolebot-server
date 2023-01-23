using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Models;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository : IDisposable
{
    public Task<List<Category>> GetCategories(string guildId);
    public Task<Category?> GetCategoryById(long categoryId);
    public Task<CategoryDto?> UpdateCategory(CategoryDto category);
    public void InsertCategory(CategoryDto category);
    public void DeleteCategory(long categoryId);
    public void Save();
}