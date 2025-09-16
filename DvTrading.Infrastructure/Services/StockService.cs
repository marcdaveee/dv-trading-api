
using dv_trading_api.Interfaces;

namespace dv_trading_api.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork) { 
        
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetCurrentStocksCount()
        {
            var transactions = await _unitOfWork.TransactionRepository.GetAllAsync();

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
