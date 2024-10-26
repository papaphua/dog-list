using DogList.Domain;
using DogList.Persistence.Core;

namespace DogList.App.Startup;

public static class RepositoryRegistration
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(
                AssemblyReference.Assembly,
                Persistence.AssemblyReference.Assembly)
            .AddClasses(classes => classes
                .AssignableToAny(typeof(Repository<>)))
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}