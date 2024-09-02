using dv_trading_api.Models;

namespace dv_trading_api.Interfaces
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();

        void Add(Transaction newTransaction);
    }
}
