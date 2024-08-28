using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace MediSys.Infra.Configurations;

[ExcludeFromCodeCoverage]
public static class ConnectionsConfiguration
{
    public static IServiceCollection AddAppConnections(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbConnection(configuration);
        return services;
    }

    private static IServiceCollection AddDbConnection(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        //var connectionString = configuration.GetConnectionString("CatalogDb");
        //services.AddDbContext<CodeflixCatalogDbContext>(
        //    options => options.UseMySql(
        //        connectionString,
        //        ServerVersion.AutoDetect(connectionString)
        //    )
        //);
        // TODO CONEXAO BANCO DE DADOS

        return services;
    }
}
