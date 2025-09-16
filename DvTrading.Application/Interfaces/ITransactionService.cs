using dv_trading_api.Models;

namespace dv_trading_api.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync();

        Task<Transaction?> GetById(int id);

        void Add(Transaction newTransaction);

        Task<int?> GetCurrentMonthTransactionsCount();
    }
}
