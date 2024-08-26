using dv_trading_api.Data;
using dv_trading_api.Dtos.Customer;
using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>?> GetAllAsync()
        {
            var customers = await _context.Customers.ToListAsync();

            return customers;
        }

        public async Task<Customer?> GetById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            return customer;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public void Update(Customer customer, UpdateCustomerDto updatedCustomer)
        {
            customer.Name = updatedCustomer.Name;
            customer.Address = updatedCustomer.Address;
            customer.Email = updatedCustomer.Email;
            customer.ContactNo = updatedCustomer.ContactNo;
        }

        public void Delete(Customer customer)
        {
            _context.Remove(customer);
        }


    }
}
