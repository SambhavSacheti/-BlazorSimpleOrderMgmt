using System.Collections.Generic;
using OrderManagement.Shared.Models;

namespace OrderManagement.WebApi.Services
{
    public interface ICustomerDataService{
         IEnumerable<Customer> GetAllCustomers();
        
    }
}
