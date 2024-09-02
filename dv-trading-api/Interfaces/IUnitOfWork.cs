namespace dv_trading_api.Interfaces
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        ITransactionRepository TransactionRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
