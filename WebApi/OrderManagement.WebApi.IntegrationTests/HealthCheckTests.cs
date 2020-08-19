using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using OrderManagement.WebApi;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace OrderManagement.WebApi.IntegrationTests
{
    public class HealthCheckTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public HealthCheckTests(WebApplicationFactory<Startup> factory)
        {
           _httpClient = factory.CreateDefaultClient(); 
        }

        [Fact]
        public async Task HealthCheck_ReturnsOK(){
            var response = await _httpClient.GetAsync("/healthcheck");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}