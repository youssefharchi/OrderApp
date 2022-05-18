using Microsoft.EntityFrameworkCore;

namespace Order.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<Model.Item> Items { get; set; }
        public DbSet<Model.Customer> Customers { get; set; }
        public DbSet<Model.OrderDetail> Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(pc => new {})
        }
    }
}