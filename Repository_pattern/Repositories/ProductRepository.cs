using Repository_pattern.Data;
//using Repository_pattern.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository_pattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _context; // Ensure correct DbContext name

        public ProductRepository(ProductDBContext context) // Constructor Injection
        {
            _context = context;
        }

        public async Task Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(); // Fixed: Use SaveChangesAsync()
        }

        public async Task<List<Product>> Get()
        {
            return await _context.Products.ToListAsync(); // Implemented Get() method
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();  // Implemented Get(id) method
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
