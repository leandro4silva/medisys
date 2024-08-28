using Microsoft.Extensions.DependencyInjection;

namespace MediSys.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
