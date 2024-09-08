namespace dv_trading_api.Dtos.Customer
{
    public class CountDto
    {
        public int? CustomerCount { get; set; } = null;
        public int? SupplierCount{ get; set; } = null;
        public int? TransactionCount{ get; set; } = null;   
        
        public int? StockCount { get; set; } = null;

    }
}
