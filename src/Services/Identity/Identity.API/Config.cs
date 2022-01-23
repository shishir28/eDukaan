// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.API
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                  new IdentityResources.Email(),
                new IdentityResource("country", new [] { "country" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
               new ApiScope("pieshophrapi",
                    "Pie Shop HR API",
                    new [] { "country" })
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
              
                // interactive client using code flow + pkce
                new Client
                {
                    RequireConsent = false,
                    RequirePkce = true,
                    ClientId = "PieShopHRM",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5002/signin-oidc" }, // URL of client apps
                    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 120,
                    AllowedScopes = { "openid", "profile", "email", "pieshophrapi" }
                },
            };
    }
}