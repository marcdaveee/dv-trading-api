using dv_trading_api.Data;

using dv_trading_api.Interfaces;

using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Customer.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dv_trading_api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();

            if (customers == null)
            {
                return Ok(null);
            }
            

            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customer = await _customerService.GetById(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                      

            var result = await _customerService.CreateNewCustomer(newCustomer);

            if (!result.IsSuccessful)
            {
                return BadRequest(new { message = "Error Occured" });
            }
            else
            {
                return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result.Data);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCustomerDto updatedCustomer)
        {
            if (id != updatedCustomer.Id)
            {
                return BadRequest("Invalid Request");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                        
            var result = await _customerService.Update(id, updatedCustomer);

            if (!result.IsSuccessful)
            {
                if(result.StatusCode == ApiStatusCode.NotFound)
                {
                    return NotFound(new {message= result.Message});
                }
                return BadRequest("Error occured");
            }

            return Ok(new {message = result.Message});

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {


            var result = await _customerService.Delete(id);

            if (!result.IsSuccessful)
            {
                if (result.StatusCode == ApiStatusCode.NotFound)
                {
                    return NotFound(new { message = result.Message });
                }                
            }
            
                return Ok(new { message = result.Message });
            
        }
    }
}
