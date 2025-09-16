using dv_trading_api.Dtos.Transaction;
using dv_trading_api.Interfaces;
using dv_trading_api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get all transactions from db; returned transactions are sorted in descending order based from its date
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();

            if (!transactions.Any())
            {
                return Ok(transactions.Select(t => t.ToTransactionDto()));
            }

            var transactionDto = transactions.Select(t => t.ToTransactionDto());

            return Ok(transactionDto);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var transaction = await _unitOfWork.TransactionRepository.GetById(id);
            if (transaction == null)
            {
                return NotFound("No transaction with id: " + id + "found");
            }

            return Ok(transaction.ToTransactionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTransactionDto newTransactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTransactionModel = newTransactionDto.ToTransactionModelFromCreateDto();

            _unitOfWork.TransactionRepository.Add(newTransactionModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return CreatedAtAction(nameof(GetById), new { id = newTransactionModel.Id }, newTransactionModel.ToTransactionDto());
            }
            else
            {
                return StatusCode(500);
            }
        }

    }
}
