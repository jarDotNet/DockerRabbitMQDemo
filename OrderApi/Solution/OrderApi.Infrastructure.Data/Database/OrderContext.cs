using Microsoft.EntityFrameworkCore;
using OrderApi.Domain.Entities;
using OrderApi.Domain.Enumerations;
using System;

namespace OrderApi.Infrastructure.Data.Database
{
    public class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
            var orders = new[]
            {
                new Order
                {
                    Id = Guid.Parse("d3e3137e-ccc9-488c-9e89-50ba354738c2"),
                    OrderState = eOrderState.Pending,
                    CustomerGuid = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    CustomerFullName = "Magic Johnson"
                },
                new Order
                {
                    Id = Guid.Parse("bffcf83a-0224-4a7c-a278-5aae00a02c1e"),
                    OrderState = eOrderState.Pending,
                    CustomerGuid = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    CustomerFullName = "Larry Bird"
                },
                new Order
                {
                    Id = Guid.Parse("58e5cd7d-856b-4224-bdff-bd8f85bf5a6d"),
                    OrderState = eOrderState.Paid,
                    CustomerGuid = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    CustomerFullName = "Michael Jordan"
                }
            };

            Order.AddRange(orders);
            SaveChanges();
        }

        public virtual DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerFullName).IsRequired();
            });
        }
    }
}