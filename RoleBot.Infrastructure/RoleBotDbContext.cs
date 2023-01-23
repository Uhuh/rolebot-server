using Microsoft.EntityFrameworkCore;
using Npgsql;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure;

public class RoleBotDbContext : DbContext
{
  private readonly IConfiguration _config;
  
  public RoleBotDbContext(IConfiguration config, DbContextOptions<RoleBotDbContext> options) : base(options)
  {
    _config = config;
  }
  
  static RoleBotDbContext() {
    NpgsqlConnection.GlobalTypeMapper
      .MapEnum<GuildReactType>()
      .MapEnum<DisplayOrder>();
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql("Host=192.168.50.36;Database=rolebot_test;Username=panku;Password=panku");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder
      .HasPostgresEnum<GuildReactType>()
      .HasPostgresEnum<DisplayOrder>();

    modelBuilder.Entity<Category>().ToTable("category");
    modelBuilder.Entity<GuildConfig>().ToTable("guild_config")
      .HasKey(g => new { g.GuildId });
  }
}
