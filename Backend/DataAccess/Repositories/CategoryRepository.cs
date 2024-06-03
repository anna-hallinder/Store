using MongoDB.Driver;
using Shared.Entities;
using Shared.Interfaces.IRepository;

namespace DataAccess.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IMongoCollection<CategoryEntity> _categories;

    public CategoryRepository(MongoDbContext context)
    {
        _categories = context.Categories;
    }

    public async Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync()
    {
        return await _categories.Find(_ => true).ToListAsync();
    }

    public async Task<CategoryEntity> GetCategoryByIdAsync(Guid id)
    {
        return await _categories.Find(c => c.CategoryId == id).FirstOrDefaultAsync();
    }

    public async Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category)
    {
        await _categories.InsertOneAsync(category);
        return category;
    }

    public async Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category)
    {
        await _categories.ReplaceOneAsync(c => c.CategoryId == category.CategoryId, category);
        return category;
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var result = await _categories.DeleteOneAsync(c => c.CategoryId == id);
        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<CategoryEntity>> SearchCategoryByNameAsync(string categoryName)
    {
        return await _categories.Find(c => c.CategoryName.ToLower().Contains(categoryName.ToLower())).ToListAsync();
    }
}
