using System.Diagnostics.Metrics;

namespace dv_trading_api.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? CustomerId { get; set; }

        public Customer? Customer { get; set; }

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public decimal NetWeight { get; set; }

        public decimal Moisture { get; set; }

        public decimal MeterKgs { get; set; }

        public decimal NetResecada { get; set; } 

        public decimal PricePerKg {  get; set; }

        public decimal Amount {  get; set; }

        public decimal NoOfSacks{  get; set; }

        public decimal Expenses {  get; set; }

        public TransactionType Type {  get; set; } 


    }
}
