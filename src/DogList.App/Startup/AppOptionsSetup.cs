using DogList.Application.Options;
using Microsoft.Extensions.Options;

namespace DogList.App.Startup;

public sealed class AppOptionsSetup(IConfiguration configuration)
    : IConfigureOptions<AppOptions>
{
    private const string AppSection = "App";

    public void Configure(AppOptions options)
    {
        // Binds the App section from appsettings.json.
        configuration.GetSection(AppSection)
            .Bind(options);
    }
}