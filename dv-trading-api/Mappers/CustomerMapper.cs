using dv_trading_api.Dtos.Customer;
using dv_trading_api.Models;

namespace dv_trading_api.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            var customerDto = new CustomerDto
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Address = customerModel.Address,
                ContactNo = customerModel.ContactNo,
                Email = customerModel.Email,
            };

            return customerDto;
        }

        public static Customer ToCustomerModelFromCreateDto(this CreateCustomerDto newCustomer)
        {
            var customerModel = new Customer
            {
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                ContactNo = newCustomer.ContactNo,
                Email = newCustomer.Email,
            };

            return customerModel;
        }
    }
}
