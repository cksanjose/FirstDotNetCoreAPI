using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace FirstDotNetCoreAPI.Integration.Tests
{
    public class StartupTests : IClassFixture<WebApplicationFactory<FirstDotNetCoreAPI.Startup>>
    {
        private readonly HttpClient _client;

        public StartupTests(WebApplicationFactory<FirstDotNetCoreAPI.Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetHomePage()
        {
            // Act
            var response = await _client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
