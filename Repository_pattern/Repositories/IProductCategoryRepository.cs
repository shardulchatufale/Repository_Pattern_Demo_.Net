//using Repository_pattern.Domain.Entities;

namespace Repository_pattern.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> Get();
        Task<ProductCategory?> Get(int id);
        Task Create(ProductCategory category);
        Task Update(ProductCategory category);
        Task Delete(ProductCategory productCategory);
    }
}
