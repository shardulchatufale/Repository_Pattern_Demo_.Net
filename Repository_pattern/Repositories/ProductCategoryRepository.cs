using Repository_pattern.Domain.Entities;
using Repository_pattern.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository_pattern.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProductDBContext _context; // Ensure correct DbContext name

        public ProductCategoryRepository(ProductDBContext context) // Constructor Injection
        {
            _context = context;
        }

        public async Task Create(ProductCategory category)
        {
            await _context.ProductCategories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProductCategory productCategory)
        {
            _context.ProductCategories.Remove(productCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProductCategory>> Get()
        {
            return await _context.ProductCategories
               .ToListAsync();
        }

        public async Task<ProductCategory?> Get(int id)
        {
            return await _context.ProductCategories
                .Include(pc => pc.Products) // Eager loading for related Products
                .FirstOrDefaultAsync(pc => pc.Id == id);
        }

        public async Task Update(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
