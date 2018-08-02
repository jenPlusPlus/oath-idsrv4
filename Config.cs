// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerPractice
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "business",
                    UserClaims = { "business_name", "fav_color" },
                    DisplayName = "Business Name & Fave Color"
                },
                new IdentityResource
                {
                    Name = "location",
                    UserClaims = { "curr_location" },
                    DisplayName = "Current Location"
                },
                new IdentityResources.Email(),
                // new IdentityResource
                // {
                //     Name = "color",
                //     UserClaims = { "fav_color" },
                //     DisplayName = "Favorite Color"
                // }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                // client credentials flow client
                // new Client
                // {
                //     ClientId = "client",
                //     ClientName = "Client Credentials Client",

                //     AllowedGrantTypes = GrantTypes.ClientCredentials,
                //     ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                //     AllowedScopes = { "api1" }
                // },

                // MVC client using hybrid flow
                new Client
                {
                    ClientId = "ideaBox",
                    ClientName = "IdeaBox Client",

                    AlwaysIncludeUserClaimsInIdToken = false,

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { "https://localhost:5001/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5001/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5001/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1", "business", "email" },
                    
                },

                new Client
                {
                    ClientId = "toDoBox",
                    ClientName = "ToDoBox Client",

                    AlwaysIncludeUserClaimsInIdToken = false,

                    AllowedGrantTypes = GrantTypes.Hybrid,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FC6A34".Sha256()) },

                    RedirectUris = { "https://localhost:5003/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5003/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5003/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1", "location", "email" },
                    
                },

                // SPA client using implicit flow
                // new Client
                // {
                //     ClientId = "spa",
                //     ClientName = "SPA Client",
                //     ClientUri = "http://identityserver.io",

                //     AllowedGrantTypes = GrantTypes.Implicit,
                //     AllowAccessTokensViaBrowser = true,

                //     RedirectUris =
                //     {
                //         "http://localhost:5002/index.html",
                //         "http://localhost:5002/callback.html",
                //         "http://localhost:5002/silent.html",
                //         "http://localhost:5002/popup.html",
                //     },

                //     PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                //     AllowedCorsOrigins = { "http://localhost:5002" },

                //     AllowedScopes = { "openid", "profile", "api1" }
                // }
            };
        }
    }
}