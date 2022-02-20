using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FakeData;
using ITF.Application.MyDeveloperProfile.Dtos;
using ITF.Tests.Common;
using Xunit;

namespace ITF.Tests;

public class DeveloperProfileControllerTests : IClassFixture<ItfWebApplicationFactory>
{
    private readonly ItfWebApplicationFactory _factory;

    public DeveloperProfileControllerTests(ItfWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetProfile_ShouldReturnProfile()
    {
        using var client = _factory
            .ClearAndSeed(FakeDataInitializer.SeedItfData)
            .CreateClientWithFakeAuth();

        var result = await client.GetAsync("/my-developer-profile");
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);

        var profile = await result.Content.ReadFromJsonAsync<DeveloperProfileDto>();
        Assert.NotNull(profile);
    }
}