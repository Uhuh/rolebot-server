using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RoleBotDbContext _context;

    public CategoryRepository(RoleBotDbContext context)
    {
        this._context = context;
    }

    public Task<List<Category>> GetCategories(string guildId)
    {
        return _context.Set<Category>()
            .Where(c => c.GuildId == guildId)
            .Include(c => c.ReactRoles)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryById(long categoryId)
    {
        return await _context.Set<Category>()
            .Where(c => c.Id == categoryId)
            .Include(c => c.ReactRoles)
            .FirstOrDefaultAsync();
    }

    public void InsertCategory(Category category)
    {
        throw new NotImplementedException();
    }

    public void DeleteCategory(long categoryId)
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