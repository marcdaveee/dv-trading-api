﻿namespace dv_trading_api.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string? ContactNo { get; set; }

        public string? Email { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
