// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace Identity.API.Configuration
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("catalog", "Catalog Service"),
                new ApiResource("basket", "Basket Service"),
                new ApiResource("discount", "Discount Service"),
                new ApiResource("orders", "Orders Service"),
                new ApiResource("webshoppingagg", "Web Shopping Aggregator")
            };
        }

        public static IEnumerable<IdentityResource> GetResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }


        public static IEnumerable<Client> GetClients(Dictionary<string, string> clientsUrl) 
        {
            return new List<Client>
            {

               new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    ClientSecrets = new List<Secret>
                    {

                        new Secret("secret".Sha256())
                    },
                    ClientUri = $"{clientsUrl["Mvc"]}",                             // public uri of the client
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    AllowAccessTokensViaBrowser = false,
                    RequireConsent = false,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    RedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        $"{clientsUrl["Mvc"]}/signout-callback-oidc"
                    },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "orders",
                        "basket",
                        "webshoppingagg",
                        "orders.signalrhub",
                        "webhooks"
                    },
                    AccessTokenLifetime = 60*60*2, // 2 hours
                    IdentityTokenLifetime= 60*60*2 // 2 hours
                },
                //new Client
                //{
                //    RequireConsent = false,
                //    RequirePkce = true,
                //    ClientId = "PieShopHRM",
                //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },
                //    AllowedGrantTypes = GrantTypes.Code,
                //    RedirectUris = { "https://localhost:5002/signin-oidc" }, // URL of client apps
                //    FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
                //    PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },
                //    AllowOfflineAccess = true,
                //    AccessTokenLifetime = 120,
                //    AllowedScopes = { "openid", "profile", "email", "pieshophrapi" }
                //},

            }

            ;
        }
          
    }
}