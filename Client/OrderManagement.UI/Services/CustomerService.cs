using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.UI.Services
{
    public class CustomerService : ICustomerService
    {
        HttpClient _httClient;

        public CustomerService(HttpClient httpClient)
        {
            _httClient = httpClient;
        }
        public Customer Get(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Customer[]> GetCustomersAsync()
        {
            var response = await _httClient.GetAsync("sample-data/Customers.json");

            using var readStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<Customer[]>(readStream);

        }
    }
}