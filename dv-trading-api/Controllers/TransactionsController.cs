using dv_trading_api.Interfaces;
using dv_trading_api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();

            if (!transactions.Any())
            {
                return Ok(transactions.Select(t => t.ToTransactionDto()));
            }

            var transactionDto = transactions.Select(t => t.ToTransactionDto());

            return Ok(transactionDto);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] )
        {

        }

    }
}
