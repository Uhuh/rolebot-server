using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

internal class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Category?> GetCategory(long categoryId)
    {
        return await _categoryRepository.GetCategoryById(categoryId);
    }

    public async Task<List<Category>> GetGuildCategories(string guildId)
    {
        return await _categoryRepository.GetCategories(guildId);
    }
}