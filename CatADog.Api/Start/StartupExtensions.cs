using CatADog.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CatADog.Api.Start;

public static class StartupExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(QueryService<>));
        services.AddScoped(typeof(CrudService<>));

        // register services in CatADog.Domain.Services project
        services.Scan(scan => scan
            .FromAssemblyOf<AnimalService>()
            .AddClasses()
            .AsSelf()
            .WithScopedLifetime());

        return services;
    }
}