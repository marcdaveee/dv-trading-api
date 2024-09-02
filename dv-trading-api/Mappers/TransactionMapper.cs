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
                Moisture = model.Moisture,
                MeterKgs = model.MeterKgs,
                NetResecada = model.NetResecada,
                PricePerKg = model.PricePerKg,
                Amount = model.Amount,
                Expenses = model.Expenses,
                Type = model.Type,
            };

               // Customer will not be null if the transaction type is 'Incoming'    
            if(model.Customer != null )
            {
                transactionDto.CustomerId = model.CustomerId;
                transactionDto.Customer = model.Customer.ToCustomerDto();
            }
            else
            {
                transactionDto.CustomerId = null;
                transactionDto.Customer = null;
            }

            // Supplier will not be null if the transaction type is 'Incoming'    
            if (model.Supplier!= null)
            {
                transactionDto.SupplierId = model.SupplierId;
                transactionDto.Supplier = model.Supplier.ToSupplierDto();
            }
            else
            {
                transactionDto.SupplierId = null;
                transactionDto.Supplier = null;
            }


            return transactionDto;
        }
    }
}
