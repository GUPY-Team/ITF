using FluentValidation;
using FluentValidation.AspNetCore;
using ITF.Application.DeveloperProfiles.Commands;
using ITF.Application.Mappings;
using ITF.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Extensions;

namespace ITF.Api;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        var services = builder.Services;

        var connectionString = builder.Configuration.GetConnectionString("Postgres");
        services.AddNpgsql<ItfDbContext>(connectionString);

        services.AddCurrentUser();

        services.AddFluentValidation();
        services.AddValidatorsFromAssembly(typeof(HostingExtensions).Assembly);

        services.AddMediatR(typeof(CreateDeveloperProfileCommand).Assembly);
        services.AddAutoMapper(typeof(DeveloperProfileMaps).Assembly);

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        return app;
    }

    public static async Task MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ItfDbContext>();
        await context.Database.MigrateAsync();
    }
}