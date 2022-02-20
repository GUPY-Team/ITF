using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ITF.Tests.Common;

public class ItfWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services
                .AddAuthentication(Constants.FakeAuthSchemeName)
                .AddScheme<AuthenticationSchemeOptions, FakeAuthHandler>(Constants.FakeAuthSchemeName, null);
        }).UseEnvironment("test")
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
    }
}