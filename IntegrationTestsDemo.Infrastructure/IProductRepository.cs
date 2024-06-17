using IntegrationTestsDemo.Domain;

namespace IntegrationTestsDemo.Infrastructure
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product?> GetProductByIdAsync(Guid id);

        Task<Guid> AddProductAsync(Product product);
    }
}
