using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderManagement.Shared.Models
{
    interface ICustomerService
{
    Customer Get(int Id);
    Task<Customer[]> GetCustomersAsync();

}
}