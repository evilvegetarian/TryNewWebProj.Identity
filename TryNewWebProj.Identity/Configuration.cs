using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace TryNewWebProj.Identity
{

    public static class Configuration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("WordWebAPI", "Web API")
            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new ApiResource("WordWebAPI", "Web API", new []
                    { JwtClaimTypes.Name})
                {
                    Scopes = {"WordWebAPI"}
                }
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "word-web-app",
                    ClientName = "Word Web",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,
                    RequirePkce = true,
                    RedirectUris =
                    {
                        "https://localhost:7000/signin-oidc"
                    },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:7000"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:7000/signout-callback-oidc"
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "WordWebAPI"
                    },
                    AllowAccessTokensViaBrowser = true
                }
            };
    }
}

