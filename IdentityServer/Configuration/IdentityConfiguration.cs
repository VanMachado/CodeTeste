using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace CodeChallenge.IdentityServer.Configuration
{
    public static class IdentityConfiguration
    {
        public const string Admin = "Admin";
        public const string Client = "Client";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
              new IdentityResources.OpenId(),
              new IdentityResources.Email(),
              new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("CodeChallenge", "Code Challenge"),
                new ApiScope(name: "read", "Read data."),
                new ApiScope(name: "write", "Write data."),
                new ApiScope(name: "delete", "Delete data.")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("my_secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = {"read", "write", "profile"}
                },
                new Client
                {
                    ClientId = "CodeChallenge",
                    ClientSecrets = { new Secret("my_secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {"https://localhost:7054/signin-oidc"},
                    PostLogoutRedirectUris = {"https://localhost:7054/signout-callback-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "CodeChallenge"
                    }
                }
            };
    }
}