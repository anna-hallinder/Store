using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface IProductRepository
{
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<ProductEntity> GetProductByIdAsync(Guid id);
    Task<ProductEntity> CreateProductAsync(ProductEntity product);
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);
    Task<bool> DeleteProductAsync(Guid id);
    Task<IEnumerable<ProductEntity>> SearchProductByNameAsync(string productName);
    Task<IEnumerable<ProductEntity>> SearchProductByArticleNumberAsync(string articleNumber);
}

