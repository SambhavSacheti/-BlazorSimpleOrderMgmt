using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using OrderManagement.Models;
using System;

namespace OrderManagement.WebApi.IntegrationTests
{
    public class CustomersControllerTests:IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public CustomersControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateDefaultClient(new Uri("http://localhost/api/Customer") );
        }

        [Fact]
        public async Task GetAllCustomers_ReturnStatusCode(){

            var response = await _client.GetAsync(string.Empty);

            response.EnsureSuccessStatusCode();
        }
        
          [Fact]
        public async Task GetAllCustomers_ReturnsExpectedMediaType(){

            var response = await _client.GetAsync(string.Empty);

           Assert.Equal("application/json", response.Content.Headers.ContentType.MediaType);
        }

        [Fact]
        public async Task GetAllCustomers_ReturnsContent(){
            
            var response = await _client.GetAsync(string.Empty);

            Assert.NotNull(null);
            Assert.True(response.Content.Headers.ContentLength>0);
        }

        [Fact]
        public async Task GetAll_ReturnsExpectedJson(){
   
             var customers = await _client.GetFromJsonAsync<Customer[]>(string.Empty);

            Assert.NotEmpty(customers);
            //Assert.IsType()

        }
        
    }
}