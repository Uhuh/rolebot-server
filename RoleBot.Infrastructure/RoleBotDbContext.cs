using Microsoft.EntityFrameworkCore;
using RoleBot.Infrastructure.Entities;

namespace RoleBot.Infrastructure;

public class RoleBotDbContext : DbContext
{
  private readonly IConfiguration _config;
  
  public RoleBotDbContext(IConfiguration config, DbContextOptions<RoleBotDbContext> options) : base(options)
  {
    this._config = config;
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=192.168.50.36;Database=rolebotBeta;Username=panku;Password=panku");

  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Category>().ToTable("category");
    modelBuilder.Entity<ReactRole>().ToTable("react_role");
  }
}
