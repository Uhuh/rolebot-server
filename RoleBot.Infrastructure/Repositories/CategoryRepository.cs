using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Dtos;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RoleBotDbContext _context;

    public CategoryRepository(RoleBotDbContext context)
    {
        this._context = context;
    }

    public Task<List<CategoryDto>> GetCategories(string guildId)
    {
        return _context.Set<Category>()
            .Where(c => c.GuildId == guildId)
            .Select(c => CategoryDto.From(c))
            .ToListAsync();
    }

    public Task<CategoryDto?> GetCategoryById(long categoryId)
    {
        return _context.Set<Category>()
            .Where(c => c.Id == categoryId)
            .Select(c => CategoryDto.From(c))
            .FirstOrDefaultAsync();
    }

    public async Task<CategoryDto> CreateCategory(CategoryDto category)
    {
        var newCategory = new Category
        {
            DisplayOrder = category.DisplayOrder,
            GuildId = category.GuildId,
            Description = category.Description,
            MutuallyExclusive = category.MutuallyExclusive,
            Name = category.Name,
            ExcludedRoleId = category.ExcludedRoleId,
            RequiredRoleId = category.RequiredRoleId,
        };

        await _context.Set<Category>().AddAsync(newCategory);

        await _context.SaveChangesAsync();

        return CategoryDto.From(newCategory);
    }

    public async Task<CategoryDto?> UpdateCategory(CategoryDto category)
    {
        var result = await _context.Set<Category>()
            .Where(c => c.Id == category.Id).FirstOrDefaultAsync();

        if (result == null)
            return null;
            
        result.Name = category.Name;
        result.Description = category.Description;
        result.MutuallyExclusive = category.MutuallyExclusive;
        result.DisplayOrder = category.DisplayOrder;

        await _context.SaveChangesAsync();

        return CategoryDto.From(result);
    }
    
    public async Task<CategoryDto?> DeleteCategory(string guildId, long categoryId)
    {
        var result = await _context.Set<Category>().Where(c => c.Id == categoryId && c.GuildId == guildId).FirstOrDefaultAsync();

        if (result == null)
            return null;

        _context.Remove(result);
        await _context.SaveChangesAsync();

        return CategoryDto.From(result);
    }

    public void InsertCategory(CategoryDto category)
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    private bool _disposed = false;
    
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this._disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}