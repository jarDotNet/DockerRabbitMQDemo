using CustomerApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerApi.Infrastructure.Data.Database
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
            var customers = new[]
            {
                new Customer
                {
                    Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    FirstName = "Magic",
                    LastName = "Johnson",
                    Birthday = new DateTime(1959, 8, 14),
                    Age = GetYears(new DateTime(1959, 8, 14))
                },
                new Customer
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    FirstName = "Larry",
                    LastName = "Bird",
                    Birthday = new DateTime(1956, 12, 7),
                    Age = GetYears(new DateTime(1956, 12, 7))
                },
                new Customer
                {
                    Id = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    FirstName = "Michael",
                    LastName = "Jordan",
                    Birthday = new DateTime(1963, 2, 17),
                    Age = GetYears(new DateTime(1963, 2, 17))
                }
            };

            Customer.AddRange(customers);
            SaveChanges();

            // Declare a local function.
            int GetYears(DateTime date)
            {
                var today = DateTime.Today;

                return
                    (today.Year - date.Year - 1) +
                    (((today.Month > date.Month) ||
                    ((today.Month == date.Month) && (today.Day >= date.Day))) ? 1 : 0);
            }
        }

        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}