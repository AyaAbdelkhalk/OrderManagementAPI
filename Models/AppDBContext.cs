using Microsoft.EntityFrameworkCore;

namespace ECommerceOrderManagementAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(op => op.Products)
                .WithMany(o => o.Orders)
                .UsingEntity<OrderProduct>();
                
        }
    }

}
