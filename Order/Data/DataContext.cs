using Microsoft.EntityFrameworkCore;
using OrderApp.Model;

namespace OrderApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderDetail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<Item>()
                .HasMany(d => d.orderDetails)
                .WithOne(i => i.item)
                .HasForeignKey(f => f.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder
                .Entity<Model.Order>()
                .HasMany(o => o.Details)
                .WithOne(d => d.order)
                .HasForeignKey(f => f.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}