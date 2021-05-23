using GroceryStore.Application.Customers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.List();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            return _customerService.Get(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] CustomerDto customerDto)
        {
            _customerService.Add(customerDto);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerDto customerDto)
        {
            _customerService.Update(customerDto);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        private void Delete(int id)
        {
            _customerService.Delete(id);
        }
    }
}
