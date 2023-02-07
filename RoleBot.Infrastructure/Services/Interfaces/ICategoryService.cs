using RoleBot.Infrastructure.Dtos;

namespace RoleBot.Infrastructure.Services.Interfaces;

public interface ICategoryService
{
    public Task<CategoryDto?> GetCategory(long categoryId);
    public Task<List<CategoryDto>> GetGuildCategories(string guildId);
    public Task<CategoryDto> CreateCategory(CategoryDto category);
    public Task<CategoryDto?> UpdateCategory(CategoryDto category);
    public Task<CategoryDto?> DeleteCategory(string guildId, long categoryId);
}