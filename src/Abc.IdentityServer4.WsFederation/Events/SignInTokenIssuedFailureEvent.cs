﻿// ----------------------------------------------------------------------------
// <copyright file="SignInTokenIssuedFailureEvent.cs" company="ABC software Ltd">
//    Copyright © ABC SOFTWARE. All rights reserved.
//
//    Licensed under the Apache License, Version 2.0.
//    See LICENSE in the project root for license information.
// </copyright>
// ----------------------------------------------------------------------------

using Abc.IdentityServer4.WsFederation.Validation;
using IdentityServer4.Events;
using IdentityServer4.Extensions;

namespace Abc.IdentityServer4.WsFederation.Events
{
    public class SignInTokenIssuedFailureEvent : TokenIssuedFailureEvent
    {
        public SignInTokenIssuedFailureEvent(ValidatedWsFederationRequest request, string error, string description)
            : base()
        {
            if (request != null)
            {
                ClientId = request.ClientId;
                ClientName = request.Client?.ClientName;

                if (request.Subject.IsAuthenticated())
                {
                    SubjectId = request.Subject.GetSubjectId();
                }
            }

            Endpoint = WsFederationConstants.EndpointNames.WsFederation;
            Error = error;
            ErrorDescription = description;
        }
    }
}