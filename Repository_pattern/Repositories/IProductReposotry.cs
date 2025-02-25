using Repository_pattern.Domain.Entities;

namespace Repository_pattern.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product?> Get(int id);
        Task Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}
