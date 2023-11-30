using BlazorServer.FactoryPatternExample.Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BlazorServer.FactoryPatternExample.Infrastructure
{
    public class FactoryPatternExampleContext: DbContext
    {
        public FactoryPatternExampleContext(DbContextOptions<FactoryPatternExampleContext> options) : base(options) { }

        DbSet<State> States => Set<State>();
        DbSet<Product> Products => Set<Product>();
        DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Comment = "This is a Car", Cost = 999.99, Description = "Car", Name = "Civic"},    
                new Product { Id = 2, Comment = "This is a Bus", Cost = 9999.99, Description = "Bus", Name = "Grey Hound"},    
                new Product { Id = 3, Comment = "This is a Truck", Cost = 4999.99, Description = "Truck", Name = "Tacoma"}    
            );

            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Abbreviation = "CA", Name = "California", Comment = "California", Description = "California" },   
                new State { Id = 2, Abbreviation = "AZ", Name = "Arizona", Comment = "Arizona", Description = "Arizona" },    
                new State { Id = 3, Abbreviation = "NY", Name = "New York", Comment = "New York", Description = "New York" }    
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, AmountOrder = 1, Comment = "Order 1", Description = "Order 1", Name = "Order 1", ShippingCost = 10, Total = 1009.99, ProductId = 1, StateId = 1},
                new Order { Id = 2, AmountOrder = 1, Comment = "Order 2", Description = "Order 2", Name = "Order 2", ShippingCost = 20, Total = 1019.99, ProductId = 1, StateId = 2},
                new Order { Id = 3, AmountOrder = 1, Comment = "Order 3", Description = "Order 3", Name = "Order 3", ShippingCost = 50, Total = 1059.99, ProductId = 1, StateId = 3}
            );
        }
    }
}
