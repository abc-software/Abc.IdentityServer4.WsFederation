﻿using Microsoft.IdentityModel.Protocols.WsFederation;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer4.WsFederation.Validation
{
    public interface ISignInValidator
    {
        Task<SignInValidationResult> ValidateAsync(WsFederationMessage message, ClaimsPrincipal user);
    }
}