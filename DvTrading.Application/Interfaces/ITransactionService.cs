using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Transaction.Request;
using DvTrading.Application.DTOs.Transaction.Response;

namespace dv_trading_api.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();

        Task<TransactionDto?> GetById(int id);

        Task<DbTransactionResult<TransactionDto>> Add(CreateTransactionDto newTransaction);

        Task<int?> GetCurrentMonthTransactionsCount();
    }
}
