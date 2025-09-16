using dv_trading_api.Models;
using DvTrading.Application.DTOs.Supplier.Request;

namespace dv_trading_api.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>?> GetAllSupplier();

        Task<Supplier?> GetSupplierById(int id);

        void AddSupplier(Supplier supplierModel);

        void UpdateSupplier(Supplier supplierModel, UpdateSupplierDto updatedSupplier);

        void DeleteSupplier(Supplier supplierModel);

        Task<int?> GetCount();
    }
}
