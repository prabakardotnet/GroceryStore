using GroceryStore.Application.Customers;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CustomerDto> Get(int id)
        {
            if (!_customerService.Exists(id))
                return NotFound();
            return _customerService.Get(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CustomerDto> Post(CustomerDto customerDto)
        {
            int newId = _customerService.Add(customerDto);
            return CreatedAtAction(nameof(Get), new { id = newId });
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<CustomerDto> Put(int id, CustomerDto customerDto)
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        private IActionResult Delete(int id)
        {
            if (!_customerService.Exists(id))
                return NotFound();
            _customerService.Delete(id);
            return NoContent();
        }
    }
}
