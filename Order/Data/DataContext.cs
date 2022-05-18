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
    }
}