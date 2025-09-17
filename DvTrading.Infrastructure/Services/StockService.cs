
using dv_trading_api.Data;
using dv_trading_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Services
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _context;

        public StockService(AppDbContext context) { 
        
            _context = context;
        }

        public async Task<int> GetCurrentStocksCount()
        {
            var transactions = await _context.Transactions.ToListAsync();

            //DateTime currentDate = DateTime.UtcNow;

            //var currentYear = currentDate.Year;
            //var currentMonth = currentDate.Month;

            //var currMonthTransactions = transactions.Where(t => t.Date.Year == currentYear).ToList();

            int totalIncomingCopras = 0;
            int totalOutgoingCopras = 0;

            foreach (var transaction in transactions)
            {
                if(transaction.Type == 0)
                {
                    totalIncomingCopras = (int)(totalIncomingCopras + transaction.NetWeight);
                }
                else
                {
                    totalOutgoingCopras = (int)(totalOutgoingCopras + transaction.NetWeight);
                }
            }

            var currentStock = totalIncomingCopras - totalOutgoingCopras;

            return currentStock;
        }
    }
}
