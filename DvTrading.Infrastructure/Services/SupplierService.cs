using dv_trading_api.Data;

using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using DvTrading.Application.DTOs.Common.Response;
using DvTrading.Application.DTOs.Supplier.Request;
using DvTrading.Application.DTOs.Supplier.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace dv_trading_api.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierDto>?> GetAllSupplier()
        {
            var suppliers = await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    ContactNo = s.ContactNo,
                    Email = s.Email,
                })
                .ToListAsync();

            return suppliers;
        }

        public async Task<SupplierDto?> GetSupplierById(int id)
        {
            var supplier = await _context.Suppliers
                .Select(s => new SupplierDto
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    ContactNo = s.ContactNo,
                    Email = s.Email,
                })
                .FirstOrDefaultAsync(s => s.Id == id);

            return supplier;
        }

        public async Task<DbTransactionResult<SupplierDto?>> AddSupplier(CreateSupplierDto supplierToAdd)
        {
            var supplierRecord = new Supplier
            {
                FirstName = supplierToAdd.FirstName,
                LastName = supplierToAdd.LastName,
                Address = supplierToAdd.Address,
                ContactNo = supplierToAdd.ContactNo,
                Email = supplierToAdd.Email,
            };
            await _context.Suppliers.AddAsync(supplierRecord);

            int affectedRows = await _context.SaveChangesAsync();

            if (affectedRows > 0)
            {
                var supplierDto = new SupplierDto
                {
                    Id = supplierRecord.Id,
                    FirstName = supplierRecord.FirstName,
                    LastName = supplierRecord.LastName,
                    Address = supplierRecord.Address,
                    ContactNo = supplierRecord.ContactNo,
                    Email = supplierRecord.Email,
                };

                return new DbTransactionResult<SupplierDto?>
                {
                    IsSuccessful = true,
                    StatusCode = ApiStatusCode.OK,
                    Data = supplierDto,
                    Message = "New supplier was saved successfully."
                };
            }

            return new DbTransactionResult<SupplierDto?> { IsSuccessful = false, StatusCode = ApiStatusCode.ServerError, Message = "Error occured while saving." };

        }

        public async Task<DbTransactionResult<SupplierDto?>> UpdateSupplier(int supplierId, UpdateSupplierDto updatedSupplier)
        {
            var supplierToUpdate = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == supplierId);

            if (supplierToUpdate == null)
            {
                return new DbTransactionResult<SupplierDto?>
                {
                    IsSuccessful = false,
                    StatusCode = ApiStatusCode.NotFound,
                    Message = "Supplier to be updated was not found."
                };
            }


            supplierToUpdate.FirstName = updatedSupplier.FirstName;
            supplierToUpdate.LastName = updatedSupplier.LastName;
            supplierToUpdate.Address = updatedSupplier.Address;
            supplierToUpdate.Email = updatedSupplier.Email;
            supplierToUpdate.ContactNo = updatedSupplier.ContactNo;

            await _context.SaveChangesAsync();

            return new DbTransactionResult<SupplierDto?>
            {
                IsSuccessful = true,
                StatusCode = ApiStatusCode.OK,
                Data = new SupplierDto
                {
                    Id = supplierToUpdate.Id,
                    FirstName = supplierToUpdate.FirstName,
                    LastName = supplierToUpdate.LastName,
                    Address = supplierToUpdate.Address,
                    ContactNo = supplierToUpdate.ContactNo,
                    Email = supplierToUpdate.Email,
                } ,
                Message = "Supplier was updated successfully."
            };
        }

        public async Task<DbTransactionResult<SupplierDto>> DeleteSupplier(int id)
        {
            var supplierToDelete = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);

            if (supplierToDelete == null)
            {
                return new DbTransactionResult<SupplierDto>
                {
                    IsSuccessful = false,
                    StatusCode = ApiStatusCode.NotFound,
                    Message = "Supplier to delete was not found"
                };
               
            }

            _context.Suppliers.Remove(supplierToDelete);
            await _context.SaveChangesAsync();

            return new DbTransactionResult<SupplierDto>
            {
                IsSuccessful = true,
                StatusCode = ApiStatusCode.NotFound,
                Message = "Supplier was deleted successfully."
            };
        }

        public async Task<int?> GetCount()
        {
            return await _context.Suppliers.CountAsync();
        }

        
    }
     
          
}
