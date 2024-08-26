using dv_trading_api.Interfaces;
using dv_trading_api.Repository;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public ISupplierRepository SupplierRepository => new SupplierRepository(_context);
        
        public ICustomerRepository CustomerRepository => new CustomerRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return  result > 0 ? true : false;
        }
    }
}
