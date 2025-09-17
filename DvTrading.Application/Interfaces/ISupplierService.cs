using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Supplier.Request;
using DvTrading.Application.DTOs.Supplier.Response;

namespace dv_trading_api.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>?> GetAllSupplier();

        Task<SupplierDto?> GetSupplierById(int id);

        Task<DbTransactionResult<SupplierDto>> AddSupplier(CreateSupplierDto supplierToAdd);

        Task<DbTransactionResult<SupplierDto?>>UpdateSupplier(int supplierId, UpdateSupplierDto updatedSupplier);

        Task<DbTransactionResult<SupplierDto?>> DeleteSupplier(int id);

        Task<int?> GetCount();
    }
}
