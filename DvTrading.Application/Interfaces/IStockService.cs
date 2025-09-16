namespace dv_trading_api.Interfaces
{
    public interface IStockService
    {
        Task<int> GetCurrentStocksCount();
    }
}
