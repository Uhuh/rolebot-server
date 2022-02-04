using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure;

public class RoleBotDbContext : DbContext
{
  private readonly IConfiguration _config;
  
  public RoleBotDbContext(IConfiguration config, DbContextOptions<RoleBotDbContext> options) : base(options)
  {
    this._config = config;
    Console.WriteLine("CREATED DBCONTEXT");
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    Console.WriteLine("Inside DBCONTEXT FOR PG");
    optionsBuilder.UseNpgsql(_config.GetConnectionString("DefaultConnection"));

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Category>().ToTable("category");
  }
}
