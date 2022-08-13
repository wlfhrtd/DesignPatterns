using LazyLoadDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyLoadInfrastructure
{
    public class ShoppingContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                // Microsoft.EntityFrameworkCore.Proxies uses
                // Virtual Proxy pattern (except explicit inheritance etc)
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=orders.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // tell EF to not create column & persist property into db
            modelBuilder.Entity<Customer>()
                .Ignore(c => c.ProfilePicture);
            // same for Value Holder
            //modelBuilder.Entity<Customer>()
            //    .Ignore(c => c.ProfilePictureValueHolder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
