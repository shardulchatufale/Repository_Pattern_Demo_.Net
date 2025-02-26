using Microsoft.EntityFrameworkCore;
//using Repository_pattern.Domain.Entities;

namespace Repository_pattern.Data
{
    // ✅ Ensure the class is public
    public class ProductDBContext : DbContext
    {
        // ✅ Ensure constructor parameter is public
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
