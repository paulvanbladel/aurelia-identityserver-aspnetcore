﻿/*
 * Copyright 2014 Dominick Baier, Brock Allen
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using IdentityServer4.Core;
using IdentityServer4.Core.Services.InMemory;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdSvrHost.Configuration
{
    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            var users = new List<InMemoryUser>
            {
                new InMemoryUser{Subject = "818727", Username = "alice", Password = "alice", 
                    Claims = new Claim[]
                    {
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Name, "Alice Smith"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.GivenName, "Alice"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Email, "AliceSmith@email.com"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Role, "Admin"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Role, "Geek"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.WebSite, "http://alice.com"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", Constants.ClaimValueTypes.Json)
                    }
                },
                new InMemoryUser{Subject = "88421113", Username = "bob", Password = "bob", 
                    Claims = new Claim[]
                    {
                        
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Name, "Bob Smith"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.GivenName, "Bob"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.FamilyName, "Smith"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Email, "BobSmith@email.com"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Role, "Developer"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Role, "Geek"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.PhoneNumber,"01612345"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.WebSite, "http://bob.com"),
                        new Claim(IdentityServer4.Core.Constants.ClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", Constants.ClaimValueTypes.Json)
                    }
                },
            };

            return users;
        }
    }
}