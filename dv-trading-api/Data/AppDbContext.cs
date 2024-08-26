using dv_trading_api.Models;
using Microsoft.EntityFrameworkCore;

namespace dv_trading_api.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {           
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                {
                    Id = 1, 
                    Name = "ENTOM", 
                    Address="Tayabas", 
                    ContactNo= "09231412823", 
                    Email = "entom@gmail.com"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Global",
                    Address = "Lucena",
                    ContactNo = "09441416123",
                    Email = "global.ph@gmail.com"
                }   
            );

            modelBuilder.Entity<Supplier>().HasData(
              new Supplier
              {
                  Id = 1,
                  FirstName = "Ka",
                  LastName = "Rudy",
                  Address = "Bagong Niing",
                  ContactNo = "09231412823",
                  Email = ""
              },
              new Supplier
              {
                  Id = 2,
                  FirstName = "Ka",
                  LastName = "Abling",
                  Address = "Rosario",
                  ContactNo = "09223412823",
                  Email = "abling@gmail.com"
              },
              new Supplier
              {
                  Id = 3,
                  FirstName = "Alvin",
                  LastName = "Cordova",
                  Address = "Blessed",
                  ContactNo = "+63 9223252823",
                  Email = "cordova123@gmail.com"
              },
              new Supplier
              {
                  Id = 4,
                  FirstName = "Richard",
                  LastName = "D.",
                  Address = "Rosario",
                  ContactNo = "09223252823",
                  Email = ""
              }
          );
        }

    }
}
