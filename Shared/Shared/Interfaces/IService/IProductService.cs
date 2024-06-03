using Shared.Dtos.Product;
using Shared.Entities;

namespace Shared.Interfaces.IService;

public interface IProductService
{
    Task<IEnumerable<ReadProductDto>> GetAllProductsAsync();
    Task<ReadProductDto> GetProductByIdAsync(Guid id);
    Task<ReadProductDto> CreateProductAsync(CreateProductDto product);
    Task<ReadProductDto> UpdateProductAsync(Guid id, UpdateProductDto product);
    Task<bool> DeleteProductAsync(Guid id);
    Task<IEnumerable<ReadProductDto>> SearchProductByNameAsync(string productName);
    Task<IEnumerable<ReadProductDto>> SearchProductByArticleNumberAsync(string articleNumber);
}
