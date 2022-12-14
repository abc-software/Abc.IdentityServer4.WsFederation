// ----------------------------------------------------------------------------
// <copyright file="IWsTrustUriHttpClient.cs" company="ABC software Ltd">
//    Copyright © ABC SOFTWARE. All rights reserved.
//
//    Licensed under the Apache License, Version 2.0.
//    See LICENSE in the project root for license information.
// </copyright>
// ----------------------------------------------------------------------------

using IdentityServer4.Models;
using System.Threading.Tasks;

namespace Abc.IdentityServer4.WsFederation.Services
{
    /// <summary>
    /// Models making HTTP requests for WS-Trust request or response from the authorize endpoint.
    /// </summary>
    public interface IWsTrustUriHttpClient
    {
        /// <summary>Gets a WS-Trust request or response from the URL.</summary>
        /// <param name="url">The URL.</param>
        /// <param name="client">The client.</param>
        /// <returns>The WS-Trust request or response.</returns>
        Task<string> GetWsTrustAsync(string url, Client client);
    }
}