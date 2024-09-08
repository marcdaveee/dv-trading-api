using dv_trading_api.Data;
using dv_trading_api.Dtos.Supplier;
using dv_trading_api.Interfaces;
using dv_trading_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly AppDbContext _context;

        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>?> GetAllSupplier()
        {
            var suppliers = await _context.Suppliers.ToListAsync();

            return suppliers;
        }

        public async Task<Supplier?> GetSupplierById(int id)
        {
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Id == id);
            return supplier;
        }

        public void AddSupplier(Supplier supplierModel)
        {
            _context.Add(supplierModel);
        }

        public void UpdateSupplier(Supplier supplierModel, UpdateSupplierDto updatedSupplier)
        {
            supplierModel.FirstName = updatedSupplier.FirstName;
            supplierModel.LastName = updatedSupplier.LastName;
            supplierModel.Address = updatedSupplier.Address;
            supplierModel.Email = updatedSupplier.Email;
            supplierModel.ContactNo = updatedSupplier.ContactNo;
        }

        public void DeleteSupplier(Supplier supplierModel)
        {
            _context.Remove(supplierModel);
        }

        public async Task<int?> GetCount()
        {
            return await _context.Suppliers.CountAsync();
        }
    }
}
