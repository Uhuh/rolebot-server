using Microsoft.EntityFrameworkCore;
using Npgsql;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Repositories.Interfaces;

namespace RoleBot.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository, IDisposable
{
    private RoleBotDbContext _context;

    public CategoryRepository(RoleBotDbContext context)
    {
        this._context = context;
    }

    public IEnumerable<Category> GetCategories(string guildId)
    {
        return new[]
        {
            new Category()
            {
                id = 2,
                description = "Billy BOB",
                name = "Bobs Shop",
                guildId = "647960154079232041",
                mutuallyExclusive = true
            }
        };
    }

    public async Task<Category?> GetCategoryById(long categoryId)
    {
        return await _context.Set<Category>().Where(c => c.id == categoryId).FirstOrDefaultAsync();
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

    private bool disposed = false;
    
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}