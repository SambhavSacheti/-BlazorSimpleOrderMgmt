using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Shared.Models;
using System.IO;
using System.Text.Json;
using OrderManagement.WebApi.Data;
using Microsoft.AspNetCore.Http;
using OrderManagement.WebApi.Services;

namespace OrderManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        private OrderManagementDbContext _context;
        private readonly ICustomerDataService _customerDataService;


        public CustomerController(ILogger<CustomerController> logger,ICustomerDataService customerDataService, OrderManagementDbContext context)
        {
            _context = context;
            _logger = logger;
            _customerDataService = customerDataService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
            return new ActionResult<IEnumerable<Customer>>( _customerDataService.GetAllCustomers());
        }


        [HttpPost]
        public  async Task<ActionResult<Customer>> Post(Customer newCustomer)
        {
              newCustomer.id = Guid.NewGuid();
            _context.Customers.Add(newCustomer);
             await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAll), newCustomer);
        }


    }
}
