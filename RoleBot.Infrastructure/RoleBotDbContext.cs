using Microsoft.EntityFrameworkCore;
using Npgsql;
using RoleBot.Infrastructure.Entities;
using RoleBot.Infrastructure.Enums;

namespace RoleBot.Infrastructure;

public class RoleBotDbContext : DbContext
{
  private readonly IConfiguration _config;
  private readonly ILogger<RoleBotDbContext> _logger;

  public RoleBotDbContext(IConfiguration config, DbContextOptions<RoleBotDbContext> options, ILogger<RoleBotDbContext> logger) : base(options)
  {
    _config = config;
    _logger = logger;
  }
  
  static RoleBotDbContext() {
    NpgsqlConnection.GlobalTypeMapper
      .MapEnum<GuildReactType>()
      .MapEnum<DisplayOrder>();
  }
  
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    var connectionInfo = _config.GetSection("PsqlInfo");
    var host = connectionInfo["Host"];
    var user = connectionInfo["User"];
    var password = connectionInfo["Password"];
    var db = connectionInfo["Db"];
    
    optionsBuilder.UseNpgsql($"Host={host};Database={db};Username={user};Password={password};Include Error Detail=true");
  }
  
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder
      .HasPostgresEnum<GuildReactType>()
      .HasPostgresEnum<DisplayOrder>();

    modelBuilder.Entity<Category>().ToTable("category");
    modelBuilder.Entity<ReactRole>().ToTable("react_role");
    
    modelBuilder.Entity<GuildInfo>().ToTable("guild_info")
      .HasMany<GuildEmoji>(g => g.GuildEmojis);
    modelBuilder.Entity<GuildInfo>().ToTable("guild_info")
      .HasMany<GuildRole>(g => g.GuildRoles);
    modelBuilder.Entity<GuildEmoji>().ToTable("guild_emoji")
      .HasOne<GuildInfo>(e => e.GuildInfo);
    modelBuilder.Entity<GuildRole>().ToTable("guild_role")
      .HasOne<GuildInfo>(e => e.GuildInfo);

    modelBuilder.Entity<GuildConfig>().ToTable("guild_config");
  }
}
