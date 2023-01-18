using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RoleBot.Infrastructure.Models;
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
    services.AddScoped<IConfigRepository, ConfigRepository>();
    services.AddScoped<IRoleRepository, RoleRepository>();
    
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<IConfigService, ConfigService>();
    services.AddScoped<IRoleService, RoleService>();
  }

  public static void SetupJwt(this IServiceCollection services, IConfiguration configuration)
  {
    var jwtConfig = configuration.GetSection("JwtAuth");
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["IssuerSigningKey"]));
    var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

    var config = IssuerConfig(jwtConfig, signingKey, credentials);

    services.AddAuthentication(option =>
    {
      option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.TokenValidationParameters = config.TokenValidationParameters;
    });
      
    services.AddSingleton(config);
  }

  private static JwtConfig IssuerConfig(IConfiguration configuration, SecurityKey signingKey, SigningCredentials credentials)
  {
    var validationParams = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = configuration["Issuer"],
      ValidAudience = configuration["Audience"],
      IssuerSigningKey = signingKey
    };

    return new ( configuration["Issuer"], configuration["Audience"], credentials, validationParams, TimeSpan.FromDays(7));
  }
}
