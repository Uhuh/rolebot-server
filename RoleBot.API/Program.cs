using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using RoleBot.API.Middleware;
using RoleBot.Infrastructure;
using Refit;
using RoleBot.API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RoleBot API",
        Description = "RoleBot WebAPI"
    });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text"
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddSingleton(new AuthData(
    builder.Configuration["AuthData:ClientId"],
    builder.Configuration["AuthData:ClientSecret"],
    "",
    builder.Configuration["AuthData:GrantType"],
    builder.Configuration["AuthData:RedirectUri"]
));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

builder.Services.AddRefitClient<IDiscordApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://discord.com/api"));

builder.Services.SetupInfrastructureServices();
builder.Services.SetupJwt(builder.Configuration);
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();

app.UseCors("_myAllowSpecificOrigins");

app.UseAuthorization();
app.MapControllers();

app.Run();
