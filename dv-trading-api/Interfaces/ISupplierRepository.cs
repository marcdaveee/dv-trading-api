using dv_trading_api.Dtos.Supplier;
using dv_trading_api.Models;

namespace dv_trading_api.Interfaces
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>?> GetAllSupplier();

        Task<Supplier?> GetSupplierById(int id);

        void AddSupplier(Supplier supplierModel);

        void UpdateSupplier(Supplier supplierModel, UpdateSupplierDto updatedSupplier);

        void DeleteSupplier(Supplier supplierModel);
    }
}
