using MediSys.Infra.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.CodeAnalysis;

namespace MediSys.Infra.Configurations;

[ExcludeFromCodeCoverage]
public static class ControllerConfiguration
{
    public static IServiceCollection AddAndConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers()
            .AddCustomJsonOptions()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;
            });

        services.AddDocumentation();

        return services;
    }

    public static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddVersionedApi();
        return services;
    }

    private static IServiceCollection AddVersionedApi(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;       
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
}
