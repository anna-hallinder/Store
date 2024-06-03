using MongoDB.Driver;
using Shared.Entities;
using Shared.Interfaces.IRepository;

namespace DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IMongoCollection<ProductEntity> _products;

    public ProductRepository(MongoDbContext context)
    {
        _products = context.Products;
    }

    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        return await _products.Find(_ => true).ToListAsync();
    }

    public async Task<ProductEntity> GetProductByIdAsync(Guid id)
    {
        return await _products.Find(p => p.ProductId == id).FirstOrDefaultAsync();
    }

    public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
    {
        await _products.InsertOneAsync(product);
        return product;
    }

    public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
    {
        await _products.ReplaceOneAsync(p => p.ProductId == product.ProductId, product);
        return product;
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var result = await _products.DeleteOneAsync(p => p.ProductId == id);
        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductEntity>> SearchProductByNameAsync(string productName)
    {
        return await _products.Find(p => p.ProductName.ToLower().Contains(productName.ToLower())).ToListAsync();
    }

    public async Task<IEnumerable<ProductEntity>> SearchProductByArticleNumberAsync(string articleNumber)
    {
        return await _products.Find(p => p.ProductArticleNumber.ToLower().Contains(articleNumber.ToLower())).ToListAsync();
    }
}
