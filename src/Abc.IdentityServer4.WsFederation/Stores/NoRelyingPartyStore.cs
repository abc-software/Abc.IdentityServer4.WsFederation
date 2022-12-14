// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Threading.Tasks;

namespace Abc.IdentityServer4.WsFederation.Stores
{
    public class NoRelyingPartyStore : IRelyingPartyStore
    {
        public Task<RelyingParty> FindRelyingPartyByRealmAsync(string realm)
        {
            return Task.FromResult<RelyingParty>(null);
        }
    }
}