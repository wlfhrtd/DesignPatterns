﻿using LazyLoadDomain.Models;
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
                // .UseLazyLoadingProxies()
                .UseSqlite("Data Source=orders.db");
        }
    }
}
