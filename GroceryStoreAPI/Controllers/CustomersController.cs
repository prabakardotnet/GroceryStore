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
        public IActionResult Post(CustomerDto customerDto)
        {
            int newId = _customerService.Add(customerDto);
            return CreatedAtAction(nameof(Get), new { CustomerId = newId });
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, CustomerDto customerDto)
        {
            if (id != customerDto.Id)
                return BadRequest();
            if (!_customerService.Exists(id))
                return NotFound();
            _customerService.Update(customerDto);
            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        private IActionResult Delete(int id)
        {
            if (!_customerService.Exists(id))
                return NotFound();
            _customerService.Delete(id);
            return NoContent();
        }
    }
}
