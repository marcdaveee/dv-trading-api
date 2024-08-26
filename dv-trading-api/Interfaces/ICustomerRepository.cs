using dv_trading_api.Dtos.Customer;
using dv_trading_api.Models;

namespace dv_trading_api.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>?> GetAllAsync();
        Task<Customer?> GetById(int id);
        void Add(Customer customer);        
        void Update(Customer customerModel, UpdateCustomerDto updatedCustomer);
        void Delete(Customer customer);
    }
}
