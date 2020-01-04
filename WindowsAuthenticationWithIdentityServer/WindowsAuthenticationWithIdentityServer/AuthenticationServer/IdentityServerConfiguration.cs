using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthenticationServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiResource> Apis =>
            new[]
            {
                new ApiResource
                {
                    Name = "DemoApi1",
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("verysecretcode".Sha256())
                    },
                    Scopes = new List<Scope>
                    {
                        new Scope
                        {
                            Name = "protectedApi1",
                        }
                    }
                },
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "demoClient1",
                    AllowedGrantTypes = new List<string> {Constants.WindowsGrantType},
                    RequireClientSecret = false,
                    AllowedScopes = new List<string> {"protectedApi1"},
                }
            };
    }
}