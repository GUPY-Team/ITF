using FluentValidation;
using FluentValidation.AspNetCore;
using ITF.Api.Options;
using ITF.Application.Mappings;
using ITF.Application.MyDeveloperProfile.Commands;
using ITF.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Serilog;
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

        services.AddMediatR(typeof(CreateProfileCommand).Assembly);
        services.AddAutoMapper(typeof(DeveloperProfileMaps).Assembly);

        services.AddControllers();

        var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(o =>
            {
                o.Authority = jwtSettings.Authority;
            });
        services.AddAuthorization();

        services.AddCors(p => p.AddDefaultPolicy(pb => pb.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseForwardedHeaders();

        app.UseRouting();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/ping", async ctx => await ctx.Response.WriteAsync("Pong"));
        });

        return app;
    }

    public static async Task MigrateDatabase(this WebApplication app)
    {
        using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ItfDbContext>();
        await context.Database.MigrateAsync();
    }
}