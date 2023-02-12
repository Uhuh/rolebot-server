using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Repositories.Interfaces;

public interface ICategoryRepository : IDisposable
{
    public Task<List<CategoryDto>> GetCategories(string guildId);
    public Task<CategoryDto?> GetCategoryById(long categoryId);
    public Task<CategoryDto> CreateCategory(CategoryDto category);
    public Task<CategoryDto?> UpdateCategory(CategoryDto category);
    public Task<CategoryDto?> DeleteCategory(string guildId, long categoryId);
    public void InsertCategory(CategoryDto category);
    public void Save();
}