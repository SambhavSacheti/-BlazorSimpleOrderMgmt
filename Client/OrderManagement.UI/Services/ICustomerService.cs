using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Models;

namespace OrderManagement.UI.Services
{
    interface ICustomerService
    {
        Customer Get(int Id);
        Task<Customer[]> GetCustomersAsync();

    }
}