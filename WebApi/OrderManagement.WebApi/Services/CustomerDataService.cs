using System.Collections.Generic;
using System.Text.Json;
using OrderManagement.Shared.Models;
using OrderManagement.WebApi.Data;

namespace OrderManagement.WebApi.Services
{
    public class CustomerDataService : ICustomerDataService
    {

        private readonly OrderManagementDbContext _context;
        public CustomerDataService(OrderManagementDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
             if (_context.Database.EnsureCreated())
                 setupCustomerData();
            return new List<Customer>(_context.Customers);
        }

        private void setupCustomerData()
        {
            string fileContent;
            fileContent = System.IO.File.ReadAllText("sample-data/Customers.json");
            IEnumerable<Customer> customers = JsonSerializer.Deserialize<IEnumerable<Customer>>(fileContent);
            _context.Customers.AddRange(customers);
            _context.SaveChanges();
        }

    }
}
