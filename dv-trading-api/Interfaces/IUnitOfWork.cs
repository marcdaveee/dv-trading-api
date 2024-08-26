namespace dv_trading_api.Interfaces
{
    public interface IUnitOfWork
    {
        ISupplierRepository SupplierRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
