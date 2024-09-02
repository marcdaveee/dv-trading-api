using dv_trading_api.Dtos.Transaction;
using dv_trading_api.Models;

namespace dv_trading_api.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToTransactionDto(this Transaction model)
        {
            var transactionDto = new TransactionDto
            {
                Id = model.Id,                
                NetWeight = model.NetWeight,
                CustomerId = model.CustomerId,
                SupplierId = model.SupplierId,
                Moisture = model.Moisture,
                MeterKgs = model.MeterKgs,
                NetResecada = model.NetResecada,
                PricePerKg = model.PricePerKg,
                Amount = model.Amount,
                NoOfSacks = model.NoOfSacks,
                Expenses = model.Expenses,
                Type = model.Type,
            };

            // Customer will not be null if the transaction type is 'Incoming'    
            if ( model.Customer != null )
            {               
                transactionDto.Customer = model.Customer.ToCustomerDto();
            }
            else
            {          
                transactionDto.Customer = null;
            }

            // Supplier will not be null if the transaction type is 'Incoming'    
            if (model.Supplier != null)
            {                
                transactionDto.Supplier = model.Supplier.ToSupplierDto();
            }
            else
            {                
                transactionDto.Supplier = null;
            }


            return transactionDto;
        }

        public static Transaction ToTransactionModelFromCreateDto(this CreateTransactionDto newTransactionDto)
        {
            var transaction = new Transaction
            {
                CustomerId = newTransactionDto.CustomerId,
                SupplierId = newTransactionDto.SupplierId,
                NetWeight = newTransactionDto.NetWeight,
                Moisture = newTransactionDto.Moisture,
                MeterKgs = newTransactionDto.MeterKgs,
                NetResecada = newTransactionDto.NetResecada,
                PricePerKg = newTransactionDto.PricePerKg,
                Amount = newTransactionDto.Amount,
                NoOfSacks = newTransactionDto.NoOfSacks,
                Expenses = newTransactionDto.Expenses,
                Type = newTransactionDto.Type
            };

            return transaction;
        }

    }
}
