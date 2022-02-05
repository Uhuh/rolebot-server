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
    services.AddDbContext<RoleBotDbContext>();

    // Add our services so that we can DI later.
    services.AddScoped<IJwtService, JwtService>();
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    services.AddScoped<ICategoryService, CategoryService>();
  }
}
