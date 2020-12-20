using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Buchhandlung.Auth
{
    public static class Configuration
    {
        public static IEnumerable<Client> GetClients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "buchhandlungsklient",
                    ClientName = "Buchhandlung's Angular Client",
                    RequireClientSecret = false,

                    AccessTokenType = AccessTokenType.Jwt,
                    AccessTokenLifetime = 330,
                    IdentityTokenLifetime = 30,
                    RequirePkce = true,

                    AllowAccessTokensViaBrowser = true,

                    RedirectUris = new List<string> { "http://localhost:4200", "http://localhost:4200/silent-renew.html" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:4200" },
                    AllowedCorsOrigins = new List<string> { "http://localhost:4200" },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "role",
                        "bh.api.full",
                        "bh.api.read"
                    },

                    RequireConsent = false,
                }
            };

        public static IEnumerable<IdentityResource> GetIdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource{Name = "role", UserClaims  = { ClaimTypes.Role } }
            };

        public static IEnumerable<ApiResource> GetApiResources() => new List<ApiResource>
        {
            new ApiResource("Buchhandlungsapi", "Buchhandlung's API")
            {
                ApiSecrets =
                {
                    new Secret("TopSecret2".Sha256())
                },
                Scopes =
                {
                    "bh.api.full",
                    "bh.api.read",
                    "bh.api.admin"
                },
                UserClaims = {
                    "role"
                }
            }
        };

        public static IEnumerable<ApiScope> GetApiScopes() =>
            new List<ApiScope>
            {
                new ApiScope("bh.api.full", "Full access to API"),
                new ApiScope("bh.api.read", "Read-only access to API"),
                new ApiScope("bh.api.admin", "Administrator-only access to API")
            };

        public static string[] GetRoles() => new string[] {"User", "Power User", "Administrator"};
    }
}
