﻿using FluentAssertions;
using IdentityServer4.Configuration;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Abc.IdentityServer4.WsFederation.Endpoints.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Protocols.WsFederation;
using Xunit;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.IdentityServer4.WsFederation.Endpoints.Results.UnitTests
{
    public class MetadataResultFixture
    {
        private WsFederationConfigurationEx _config;
        private MetadataResult _target;
        private DefaultHttpContext _context;

        public MetadataResultFixture()
        {
            _context = new DefaultHttpContext();
            _context.SetIdentityServerOrigin("https://server");
            _context.SetIdentityServerBasePath("/");
            _context.Response.Body = new MemoryStream();

            _config = new WsFederationConfigurationEx()
            {
                Issuer = "urn:issuer",
                TokenEndpoint = "https://localhost/wsfed",
            };

            _target = new MetadataResult(_config);
        }

        [Fact]
        public void metadata_ctor()
        {
            Action action = () =>
            {
                _target = new MetadataResult(null);
            };

            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task metadata_should_pass_results_in_body()
        {
            await _target.ExecuteAsync(_context);
            _context.Response.StatusCode.Should().Be(200);
            _context.Response.ContentType.Should().Contain("application/xml");

            _context.Response.Body.Seek(0, SeekOrigin.Begin);
            using (var rdr = new StreamReader(_context.Response.Body))
            {
                var xml = rdr.ReadToEnd();
                xml.Should().Contain(@"<EntityDescriptor entityID=""urn:issuer""");
            }
        }
    }
}