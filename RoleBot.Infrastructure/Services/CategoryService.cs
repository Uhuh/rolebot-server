using RoleBot.Infrastructure.Dtos;
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

    public Task<CategoryDto?> GetCategory(long categoryId) =>_repository.GetCategoryById(categoryId);
    public Task<CategoryDto> CreateCategory(CategoryDto category) => _repository.CreateCategory(category);
    public Task<List<CategoryDto>> GetGuildCategories(string guildId) =>  _repository.GetCategories(guildId);
    public Task<CategoryDto?> UpdateCategory(CategoryDto category) => _repository.UpdateCategory(category);

    public Task<CategoryDto?> DeleteCategory(string guildId, long categoryId) =>
        _repository.DeleteCategory(guildId, categoryId);
}