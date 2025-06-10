using FastEndpoints;
using FastEndpoints.Swagger;
using ProjectName.Application;

namespace ProjectName.WebApi.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddProblemDetails();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();

        // Register FastEndpoints
        services.AddFastEndpoints(options =>
            {
                options.IncludeAbstractValidators = true;
            })
            .SwaggerDocument();
        
        // Register Application services
        services.AddApplication();
        
        return services;
    }
}