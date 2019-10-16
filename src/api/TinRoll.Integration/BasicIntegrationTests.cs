using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TinRoll.Integration
{
    public class BasicIntegrationTests
            : IClassFixture<IntegrationWebAppFactory<Api.Startup>>
    {
        private readonly IntegrationWebAppFactory<Api.Startup> _factory;
        public BasicIntegrationTests(IntegrationWebAppFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/answers")]
        [InlineData("/api/questions")]
        [InlineData("/api/tags")]
        [InlineData("/api/tags/search/text")]
        [InlineData("/api/users")]
        public async Task TestGetEndpointsSuccessful(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            response.Content.Headers.ContentType.ToString()
                .Should().Be("application/json; charset=utf-8");
        }

        [Theory]
        [InlineData("/api/answers/1")]
        [InlineData("/api/questions/1")]
        [InlineData("/api/tags/1")]
        [InlineData("/api/tags/question/1")]
        public async Task Test_GetResourceNotFound(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
            response.Content.Headers.ContentType.ToString()
                .Should().Be("application/json; charset=utf-8");
        }
    }
}
