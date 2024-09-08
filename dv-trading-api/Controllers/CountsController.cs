using dv_trading_api.Data;
using dv_trading_api.Dtos.Customer;
using dv_trading_api.Helpers;
using dv_trading_api.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dv_trading_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockService _stockService;
        public CountsController(IUnitOfWork unitOfWork, IStockService stockService) {
            _unitOfWork = unitOfWork;
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult?> GetAll([FromQuery] CountQueryObject? countQueryObject) { 

            var countModel = new CountDto();
            
            if(countQueryObject != null)
            {
                foreach (var type in countQueryObject.Types) {
                    if (type != null)
                    {
                        if (type.Equals("customer"))
                        {
                            countModel.CustomerCount = await _unitOfWork.CustomerRepository.GetCount();
                        }
                        else if (type.Equals("supplier"))
                        {
                            countModel.SupplierCount = await _unitOfWork.SupplierRepository.GetCount();
                        }
                        else if (type.Equals("stocks"))
                        {
                            countModel.StockCount = await _stockService.GetCurrentStocksCount();
                        }
                        else
                        {
                            countModel.TransactionCount = await _unitOfWork.TransactionRepository.GetCurrentMonthTransactionsCount();
                        }
                    }
                    
                }

                return Ok(countModel);
            }

            return Ok();
            
        }
    }
}
