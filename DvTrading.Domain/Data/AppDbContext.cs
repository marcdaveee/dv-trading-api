
using dv_trading_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace dv_trading_api.Data
{
    public class AppDbContext: IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {           
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                },

                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<Transaction>().HasOne(t => t.Customer).WithMany(c => c.Transactions).HasForeignKey(t => t.CustomerId).IsRequired(false);
            modelBuilder.Entity<Transaction>().HasOne(t => t.Supplier).WithMany(s => s.Transactions).HasForeignKey(t => t.SupplierId).IsRequired(false);

            
          
        }



    }
}
