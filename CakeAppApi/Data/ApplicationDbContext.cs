using CakeAppApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CakeAppApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomCake> CustomCakes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<IncludedProduct> IncludedProducts { get; set; }

    }
}
