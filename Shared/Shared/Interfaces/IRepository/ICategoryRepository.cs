using MongoDB.Driver;
using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface ICategoryRepository
{
    // Get all categories
    Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();

    // Get category by id
    Task<CategoryEntity> GetCategoryByIdAsync(Guid id);

    // Create category
    Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category);

    // Update category
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);

    // Delete category
    Task<bool> DeleteCategoryAsync(Guid id);

    // Search category by name
    Task<IEnumerable<CategoryEntity>> SearchCategoryByNameAsync(string categoryName);

}
