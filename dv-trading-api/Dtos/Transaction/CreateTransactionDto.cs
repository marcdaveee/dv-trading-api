
using dv_trading_api.Models;
using System.ComponentModel.DataAnnotations;

namespace dv_trading_api.Dtos.Transaction
{
    public class CreateTransactionDto
    {        

        public int? CustomerId { get; set; }
        
        public int? SupplierId { get; set; }

        [Required]                
        public decimal NetWeight { get; set; }

        [Required]

        public decimal Moisture { get; set; }

        [Required]
        public decimal MeterKgs { get; set; }

        [Required]

        public decimal NetResecada { get; set; }

        [Required]
        public decimal PricePerKg { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal NoOfSacks { get; set; }

        [Required]
        public decimal Expenses { get; set; }

        [Required]
        public TransactionType Type { get; set; }
    }
}
