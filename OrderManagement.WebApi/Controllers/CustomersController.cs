using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagement.Shared.Models;
using System.IO;
using Microsoft.AspNet.OData;
using System.Text.Json;
namespace ODataWithoutEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ILogger<CustomerController> _logger;
        string fileContent;


        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
            fileContent= System.IO.File.ReadAllText("sample-data/Customers.json");
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Customer>> Get()
        {   
            return new List<Customer>(JsonSerializer.Deserialize<IEnumerable<Customer>>(fileContent));

        }
    }
}
