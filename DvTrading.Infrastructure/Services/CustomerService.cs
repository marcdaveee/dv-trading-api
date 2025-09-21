

using dv_trading_api.Data;
using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Customer.Request;
using DvTrading.Application.DTOs.Customer.Response;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Repository
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _context.Customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    ContactNo = c.ContactNo,
                    Email = c.Email,
                }).
                ToListAsync();

            return customers;
        }

        public async Task<CustomerDto?> GetById(int id)
        {
            var customer = await _context.Customers.Where(c => c.Id == id)
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Address = c.Address,
                    ContactNo = c.ContactNo,
                    Email = c.Email,
                })
                .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<DbTransactionResult<CustomerDto>> CreateNewCustomer(CreateCustomerDto customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Address = customer.Address,
                ContactNo = customer.ContactNo,
                Email = customer.Email,
            };
            await _context.Customers.AddAsync(newCustomer);
            var affectedRows = await _context.SaveChangesAsync();

            if (affectedRows > 0)
            {
                return new DbTransactionResult<CustomerDto>()
                {
                    IsSuccessful = true,
                    StatusCode = ApiStatusCode.OK,
                    Message = "New Customer Record was added!",
                    Data = new CustomerDto()
                    {
                        Name = customer.Name,
                        Address = customer.Address,
                        ContactNo = customer.ContactNo,
                        Email = customer.Email
                    }
                };
            }

            return new DbTransactionResult<CustomerDto>()
            {
                IsSuccessful = false,
                StatusCode = ApiStatusCode.ServerError,
                Message = "Error occured while adding record in DB"
            };

        }

        public async Task<DbTransactionResult<CustomerDto?>> Update(int customerId, UpdateCustomerDto updatedCustomer)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return new DbTransactionResult<CustomerDto?>()
                {
                    IsSuccessful = false,
                    StatusCode = ApiStatusCode.NotFound,
                    Message = $"Customer with ID: {customerId} to update not found."
                };
            }

            customer.Name = updatedCustomer.Name;
            customer.Address = updatedCustomer.Address;
            customer.Email = updatedCustomer.Email;
            customer.ContactNo = updatedCustomer.ContactNo;

            await _context.SaveChangesAsync();

            return new DbTransactionResult<CustomerDto?>()
            {
                IsSuccessful = true,
                StatusCode = ApiStatusCode.OK,
                Message = "New Customer Record was updated!",
                Data = new CustomerDto()
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    ContactNo = customer.ContactNo,
                    Email = customer.Email
                }
            };
        }

        public async Task<DbTransactionResult<CustomerDto?>> Delete(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == customerId);

            if (customer == null)
            {
                return new DbTransactionResult<CustomerDto?>()
                {
                    IsSuccessful = false,
                    StatusCode = ApiStatusCode.NotFound,
                    Message = $"Customer with ID: {customerId} to update not found."
                };
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();

            return new DbTransactionResult<CustomerDto?>()
            {
                IsSuccessful = true,
                StatusCode = ApiStatusCode.OK,
                Message = "Customer was deleted!",
               
            };
        }

        public async Task<int?> GetCount()
        {
            return await _context.Customers.CountAsync();
        }



    }




}

