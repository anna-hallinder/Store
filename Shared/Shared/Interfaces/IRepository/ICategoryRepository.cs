using MongoDB.Driver;
using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryEntity>> GetAllCategoriesAsync();
    Task<CategoryEntity> GetCategoryByIdAsync(Guid id);
    Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category);
    Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);
    Task<bool> DeleteCategoryAsync(Guid id);
    Task<IEnumerable<CategoryEntity>> SearchCategoryByNameAsync(string categoryName);
}
