using dv_trading_api.Dtos.Supplier;
using dv_trading_api.Models;

namespace dv_trading_api.Mappers
{
    public static class SupplierMapper
    {

        public static SupplierDto toSupplierDto(this Supplier model)
        {
            var supplierDto = new SupplierDto
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                ContactNo = model.ContactNo,
                Email = model.Email
            };

            return supplierDto;
        }

        public static Supplier toSupplierModelFromCreate(this CreateSupplierDto newSupplier)
        {
            var supplierModel = new Supplier
            {
                FirstName = newSupplier.FirstName,
                LastName = newSupplier.LastName,
                Address = newSupplier.Address,
                ContactNo = newSupplier.ContactNo,
                Email = newSupplier.Email
            };

            return supplierModel;
        }

    }
}
