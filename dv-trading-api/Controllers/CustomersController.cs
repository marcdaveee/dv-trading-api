using dv_trading_api.Data;
using dv_trading_api.Dtos.Customer;
using dv_trading_api.Interfaces;
using dv_trading_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _unitOfWork.CustomerRepository.GetAllAsync();

            if (customers == null)
            {
                return Ok(null);
            }

            var customerDtoList = customers.Select(c => c.ToCustomerDto());

            return Ok(customerDtoList);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var customerModel = await _unitOfWork.CustomerRepository.GetById(id);

            if (customerModel == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customerModel.ToCustomerDto());
        }

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerModel = newCustomer.ToCustomerModelFromCreateDto();

            _unitOfWork.CustomerRepository.Add(customerModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return CreatedAtAction(nameof(GetById), new { id = customerModel.Id }, customerModel.ToCustomerDto());
            }
            else
            {
                return BadRequest("Error Occured");
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

            var customerModel = await _unitOfWork.CustomerRepository.GetById(id);

            if (customerModel == null)
            {
                return NotFound("Customer not Found");
            }

            _unitOfWork.CustomerRepository.Update(customerModel, updatedCustomer);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return Ok(customerModel.ToCustomerDto());
            }
            else
            {
                return BadRequest("Error occured");
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var customerModel = await _unitOfWork.CustomerRepository.GetById(id);

            if (customerModel == null)
            {
                return NotFound("Customer not Found");
            }

            _unitOfWork.CustomerRepository.Delete(customerModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Error occured");
            }
        }
    }
}
