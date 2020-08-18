using System.Collections.Generic;
using OrderManagement.Models;

namespace OrderManagement.WebApi.Services
{
    public interface ICustomerDataService{
         IEnumerable<Customer> GetAllCustomers();
        
    }
}
