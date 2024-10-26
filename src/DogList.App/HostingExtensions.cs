using DogList.App.Startup;
using DogList.Application.Core;
using DogList.Persistence;
using Microsoft.EntityFrameworkCore;
using AssemblyReference = DogList.Presentation.AssemblyReference;

namespace DogList.App;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddApplicationPart(AssemblyReference.Assembly);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IUnitOfWork>(provider =>
            provider.GetRequiredService<ApplicationDbContext>());

        builder.Services.RegisterRepositories();
        builder.Services.RegisterServices();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapControllers();

        app.Run();

        return app;
    }
}