using dv_trading_api.Data;
using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Customer.Response;
using DvTrading.Application.DTOs.Supplier.Response;
using DvTrading.Application.DTOs.Transaction.Request;
using DvTrading.Application.DTOs.Transaction.Response;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Repository
{
    public class TransactionRepository : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TransactionDto>> GetAllAsync()
        {
            var transactions = await _context.Transactions
                .Select(t => new TransactionDto
                {
                    Id=t.Id,
                    Date= t.Date,
                    CustomerId = t.CustomerId,
                    Customer = t.Customer != null 
                        ? new CustomerDto
                            {
                                Id=t.Customer.Id,
                                Name=  t.Customer.Name,
                                Address =t.Customer.Address,
                                ContactNo = t.Customer.ContactNo,
                                Email = t.Customer.Email
                            }
                        : null,
                    SupplierId = t.SupplierId,
                    Supplier = t.Supplier != null 
                        ? new SupplierDto
                        {
                            Id = t.Supplier.Id,
                            FirstName = t.Supplier.FirstName,
                            LastName   = t.Supplier.LastName,
                            Address=t.Supplier.Address,
                            ContactNo = t.Supplier.ContactNo,
                            Email = t.Supplier.Email
                        }
                        : null,
                    NetResecada = t.NetResecada,
                    NetWeight= t.NetWeight,
                    Moisture= t.Moisture,
                    MeterKgs=   t.MeterKgs,
                    PricePerKg= t.PricePerKg,
                    Amount= t.Amount,
                    NoOfSacks= t.NoOfSacks,
                    Expenses= t.Expenses,
                    Type = t.Type
                })
                .OrderByDescending(t => t.Date).AsNoTracking().ToListAsync();

            return transactions;
        }

        public async Task<DbTransactionResult<TransactionDto>> Add(CreateTransactionDto newTransaction)
        {
            var newTransactionRecord = new Transaction
            {
                Date = newTransaction.Date,
                CustomerId = newTransaction.CustomerId,
                SupplierId = newTransaction.SupplierId,
                NetResecada = newTransaction.NetResecada,
                NetWeight = newTransaction.NetWeight,
                Moisture = newTransaction.Moisture,
                MeterKgs = newTransaction.MeterKgs,
                PricePerKg = newTransaction.PricePerKg,
                Amount = newTransaction.Amount,
                NoOfSacks = newTransaction.NoOfSacks,
                Expenses = newTransaction.Expenses,
                Type = newTransaction.Type
            };

            await _context.Transactions.AddAsync(newTransactionRecord);

            await _context.SaveChangesAsync();

            return new DbTransactionResult<TransactionDto>
            {
                IsSuccessful = true,
                Data = new TransactionDto
                {
                    Id = newTransactionRecord.Id,
                    Date = newTransactionRecord.Date,
                    CustomerId = newTransactionRecord.CustomerId,
                    SupplierId = newTransactionRecord.SupplierId,
                    NetResecada = newTransactionRecord.NetResecada,
                    NetWeight = newTransactionRecord.NetWeight,
                    Moisture = newTransactionRecord.Moisture,
                    MeterKgs = newTransactionRecord.MeterKgs,
                    PricePerKg = newTransactionRecord.PricePerKg,
                    Amount = newTransactionRecord.Amount,
                    NoOfSacks = newTransactionRecord.NoOfSacks,
                    Expenses = newTransactionRecord.Expenses,
                    Type = newTransactionRecord.Type
                },
                Message = "New transaction was recorded successfully"
            };
        }

        public async Task<TransactionDto?> GetById(int id)
        {
            var transaction = await _context.Transactions
                .Select(t => new TransactionDto
                {
                    Id = t.Id,
                    Date = t.Date,
                    CustomerId = t.CustomerId,
                    Customer = t.Customer != null
                        ? new CustomerDto
                        {
                            Id = t.Customer.Id,
                            Name = t.Customer.Name,
                            Address = t.Customer.Address,
                            ContactNo = t.Customer.ContactNo,
                            Email = t.Customer.Email
                        }
                        : null,
                    SupplierId = t.SupplierId,
                    Supplier = t.Supplier != null
                        ? new SupplierDto
                        {
                            Id = t.Supplier.Id,
                            FirstName = t.Supplier.FirstName,
                            LastName = t.Supplier.LastName,
                            Address = t.Supplier.Address,
                            ContactNo = t.Supplier.ContactNo,
                            Email = t.Supplier.Email
                        }
                        : null,
                    NetResecada = t.NetResecada,
                    NetWeight = t.NetWeight,
                    Moisture = t.Moisture,
                    MeterKgs = t.MeterKgs,
                    PricePerKg = t.PricePerKg,
                    Amount = t.Amount,
                    NoOfSacks = t.NoOfSacks,
                    Expenses = t.Expenses,
                    Type = t.Type
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);

            return transaction;
        }

        public async Task<int?> GetCurrentMonthTransactionsCount()
        {
            var currentMonthTransactionCount = await _context.Transactions.CountAsync();

            return currentMonthTransactionCount;
        }
    }
}
