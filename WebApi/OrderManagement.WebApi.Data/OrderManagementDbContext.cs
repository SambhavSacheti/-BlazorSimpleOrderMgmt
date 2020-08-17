
using Microsoft.EntityFrameworkCore;
using OrderManagement.Shared.Models;

namespace OrderManagement.WebApi.Data
{
    public class OrderManagementDbContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public OrderManagementDbContext( DbContextOptions<OrderManagementDbContext> options):
        base(options)
        {
        
            
        }
    }
}