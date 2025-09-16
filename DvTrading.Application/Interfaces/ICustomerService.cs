
using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Customer.Request;
using DvTrading.Application.DTOs.Customer.Response;

namespace dv_trading_api.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetById(int id);
        Task<DbTransactionResult> CreateNewCustomer(CreateCustomerDto customer);
        Task<DbTransactionResult> Update(int customerId, UpdateCustomerDto updatedCustomer);
        Task<DbTransactionResult> Delete(int customerId);

        Task<int?> GetCount();
    }
}
