using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ITF.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ITF.Tests.Common;

public static class WebApplicationFactoryExtensions
{
    public static WebApplicationFactory<T> ClearAndSeed<T>(
        this WebApplicationFactory<T> factory,
        Action<ItfDbContext> configuration) where T : class
    {
        using var scope = factory.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ItfDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.Migrate();
        configuration(dbContext);

        return factory;
    }

    public static HttpClient CreateClientWithFakeAuth<T>(this WebApplicationFactory<T> factory) where T : class
    {
        var client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constants.FakeAuthSchemeName);

        return client;
    }
}