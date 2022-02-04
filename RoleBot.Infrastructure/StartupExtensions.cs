using Microsoft.EntityFrameworkCore;
using Npgsql;
using RoleBot.Infrastructure.Repositories;
using RoleBot.Infrastructure.Repositories.Interfaces;
using RoleBot.Infrastructure.Services;
using RoleBot.Infrastructure.Services.Interfaces;

namespace RoleBot.Infrastructure;

public static class StartupExtensions
{
  public static void SetupInfrastructureServices(this IServiceCollection services)
  {
    services.AddDbContext<RoleBotDbContext>(options =>
    {
      Console.WriteLine("Setting up DBContext options");
      options.UseNpgsql("Host=192.168.50.36;Database=rolebotBeta;Username=panku;Password=panku");
    });

    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<ICategoryService, CategoryService>();
  }
}
