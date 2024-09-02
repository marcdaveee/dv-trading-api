using dv_trading_api.Data;
using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync()
        {
            var transactions = await _context.Transactions.Include(t => t.Supplier).Include(t => t.Customer).AsNoTracking().ToListAsync();
            return transactions;
        }

        public void Add(Transaction newTransaction)
        {
            _context.Add(newTransaction);
        }
    }
}
