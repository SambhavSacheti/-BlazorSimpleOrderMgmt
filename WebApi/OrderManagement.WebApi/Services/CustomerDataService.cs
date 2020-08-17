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
            if (_context.Database.EnsureCreated())
            {
                if (_context.Customers == null)
                {
                    string fileContent;
                    fileContent = System.IO.File.ReadAllText("sample-data/Customers.json");
                    IEnumerable<Customer> customers = JsonSerializer.Deserialize<IEnumerable<Customer>>(fileContent);
                    _context.Customers.AddRange(customers);
                    _context.SaveChanges();
                }

            }
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return new List<Customer>(_context.Customers);
        }

        // public IEnumerable<Customer> GetCustomers()
        // {
        //     return new List<Customer>(_context.Customers.FindAsync());
        // }

    }
}
