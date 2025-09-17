
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
        Task<DbTransactionResult<CustomerDto?>> CreateNewCustomer(CreateCustomerDto customerToCreate);
        Task<DbTransactionResult<CustomerDto?>> Update(int customerId, UpdateCustomerDto updatedCustomer);
        Task<DbTransactionResult<CustomerDto?>> Delete(int customerId);

        Task<int?> GetCount();
    }
}
