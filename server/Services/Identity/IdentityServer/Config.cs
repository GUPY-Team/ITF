using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
        };

    public static IEnumerable<ApiScope> ApiScopes => Array.Empty<ApiScope>();

    public static IEnumerable<Client> Clients =>
        new[]
        {
            new Client
            {
                ClientId = "spa",

                RequireClientSecret = false,

                AllowedGrantTypes = GrantTypes.Code,

                AllowedCorsOrigins = { "http://localhost:2001" },
                PostLogoutRedirectUris = { "http://localhost:2001/logged-out" },
                RedirectUris = { "http://localhost:2001/success-auth" },

                AllowOfflineAccess = true,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OfflineAccess
                }
            },
        };
}