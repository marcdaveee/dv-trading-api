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

            //modelBuilder.Entity<Transaction>().HasData(
            //    new Transaction
            //    {
            //        Id = 1,
            //        SupplierId= 1,
            //        CustomerId = null,
            //        NetWeight = 1001,
            //        Moisture = 7,
            //        MeterKgs = 70,
            //        NetResecada = 927,
            //        PricePerKg = 30.2M,
            //        Amount = 27995,
            //        NoOfSacks = 24,
            //        Expenses = 500,
            //        Type = TransactionType.Incoming
            //    },
            //    new Transaction
            //    {
            //        Id = 2,
            //        SupplierId = 2,
            //        CustomerId = null,
            //        NetWeight = 900M,
            //        Moisture = 7.5M,
            //        MeterKgs = 67M,
            //        NetResecada = 830M,
            //        PricePerKg = 30.2M,
            //        Amount = 25066M,
            //        NoOfSacks = 21,
            //        Expenses = 500,
            //        Type = TransactionType.Incoming
            //    },
            //    new Transaction
            //    {
            //        Id = 3,
            //        SupplierId = null,
            //        CustomerId = 1,
            //        NetWeight = 6150M,
            //        Moisture = 4,
            //        MeterKgs = 246M,
            //        NetResecada = 5904M,
            //        PricePerKg = 33M,
            //        Amount = 194807M,
            //        NoOfSacks = 149,
            //        Expenses = 500,
            //        Type = TransactionType.Outgoing
            //    }
            //   );

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
