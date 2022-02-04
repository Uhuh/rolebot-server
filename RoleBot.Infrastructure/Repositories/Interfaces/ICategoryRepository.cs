using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository : IDisposable
{
    public Task<List<Category>> GetCategories(string guildId);
    public Task<Category?> GetCategoryById(long categoryId);
    public void InsertCategory(Category category);
    public void DeleteCategory(long categoryId);
    public void Save();
}