using dv_trading_api.Dtos.Supplier;
using dv_trading_api.Interfaces;
using dv_trading_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuppliersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _unitOfWork.SupplierRepository.GetAllSupplier();

            if (suppliers != null)
            {
                var suppliersDto = suppliers.Select(s => s.ToSupplierDto());
                return Ok(suppliersDto);
            }

            return Ok(null);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var supplier = await _unitOfWork.SupplierRepository.GetSupplierById(id);

            if(supplier == null)
            {
                return NotFound("Supplier not found");
            }

            return Ok(supplier.ToSupplierDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSupplierDto newSupplier) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplierModel = newSupplier.ToSupplierModelFromCreate();

            _unitOfWork.SupplierRepository.AddSupplier(supplierModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return CreatedAtAction(nameof(GetById), new {id = supplierModel.Id}, supplierModel.ToSupplierDto());
            }
            else
            {
                return BadRequest("Error occured.");
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UpdateSupplierDto updatedSupplier, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (updatedSupplier.Id != id)
            {
                return BadRequest("Invalid Request");
            }

            var supplierModel = await _unitOfWork.SupplierRepository.GetSupplierById(id);

            if (supplierModel == null)
            {
                return NotFound("Supplier not found");
            }

            _unitOfWork.SupplierRepository.UpdateSupplier(supplierModel, updatedSupplier);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return Ok(supplierModel.ToSupplierDto());
            }
            else
            {
                return BadRequest("Error occured");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var supplierModel = await _unitOfWork.SupplierRepository.GetSupplierById(id);

            if(supplierModel == null)
            {
                return NotFound("Supplier not found");
            }

            _unitOfWork.SupplierRepository.DeleteSupplier(supplierModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Error Occured");
            }

            
        }

    }
}
