namespace dv_trading_api.Interfaces
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }

        ICustomerRepository CustomerRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
