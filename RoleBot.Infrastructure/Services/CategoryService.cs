using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Models;
using RoleBot.Infrastructure.Repositories.Interfaces;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure.Services;

internal class CategoryService: ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category?> GetCategory(long categoryId)
    {
        return await _repository.GetCategoryById(categoryId);
    }

    public async Task<List<Category>> GetGuildCategories(string guildId)
    {
        return await _repository.GetCategories(guildId);
    }

    public async Task<CategoryDto?> UpdateCategory(CategoryDto category)
    {
        return await _repository.UpdateCategory(category);
    }
}