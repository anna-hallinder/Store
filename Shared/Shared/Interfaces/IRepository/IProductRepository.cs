using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface IProductRepository
{
    // Get all products
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();

    // Get product by id
    Task<ProductEntity> GetProductByIdAsync(Guid id);

    // Create product
    Task<ProductEntity> CreateProductAsync(ProductEntity product);

    // Update product
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);

    // Delete product
    Task<bool> DeleteProductAsync(Guid id);

    // Search product by name
    Task<IEnumerable<ProductEntity>> SearchProductByNameAsync(string productName);

    // Search product by article number
    Task<IEnumerable<ProductEntity>> SearchProductByArticleNumberAsync(string articleNumber);
}

