using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Identity;
using ProjectName.Application;
using ProjectName.Application.Core.Config;
using ProjectName.Application.Core.Interfaces;
using ProjectName.Application.Services;
using ProjectName.Database.DbContexts;
using ProjectName.Database.Entities;
using ProjectName.Database.PostgreSql.Extensions;

namespace ProjectName.WebApi.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddProblemDetails();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        // Register FastEndpoints
        services.AddFastEndpoints()
            .SwaggerDocument();
        
        // Register Application services
        services.AddApplication();
        
        // Register database access layer
        services.RegisterDatabaseAccess(configuration);
        
        // Register Identity services
        services.RegisterIdentity();
        
        var jwtConfig = configuration.GetSection("JwtConfig").Get<JwtConfig>();
        ArgumentNullException.ThrowIfNull(jwtConfig, "JwtConfig section is missing in the configuration.");
        services.AddSingleton(jwtConfig);
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
    
    private static void RegisterDatabaseAccess(this IServiceCollection services, IConfiguration configuration)  
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        ArgumentNullException.ThrowIfNull(connectionString);    
        services.RegisterNpgSqlDbContexts<ApplicationDbContext>(connectionString);
    }

    private static void RegisterIdentity(this IServiceCollection services)
    {
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}