using DogList.Application;

namespace DogList.App.Startup;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(AssemblyReference.Assembly)
            .AddClasses(classes => classes
                .Where(type => type.IsClass && type.Name.EndsWith("Service")))
            .AsMatchingInterface()
            .WithScopedLifetime());

        return services;
    }
}