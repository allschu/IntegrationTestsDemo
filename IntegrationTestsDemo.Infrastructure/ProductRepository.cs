using IntegrationTestsDemo.Domain;

namespace IntegrationTestsDemo.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> FakeProductsDb()         {
            return new List<Product>
            {
                new Product { Id = new Guid("5F6E4740-6ECA-4071-B76F-B1519F1D371A"), Name = "Product 1", Price = 10.00m },
                new Product { Id = new Guid("3684E2A3-5384-4A2C-84EF-74F0E8355918"), Name = "Product 2", Price = 20.00m },
                new Product { Id = new Guid("E846500D-6856-4BF9-9F81-B770BABD285A"), Name = "Product 3", Price = 30.00m }
            };
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(FakeProductsDb());
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
            var product = FakeProductsDb().FirstOrDefault(x => x.Id == id);

            return await Task.FromResult(product);
        }

        public async Task<Guid> AddProductAsync(Product product)
        {
            var newId = Guid.NewGuid();
            product.Id = newId;

            FakeProductsDb().Add(product);

            return await Task.FromResult(newId);
        }
    }
}
