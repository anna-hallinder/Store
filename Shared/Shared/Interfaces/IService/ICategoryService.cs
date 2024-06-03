using Shared.Dtos.Category;
using Shared.Entities;

namespace Shared.Interfaces.IService;

public interface ICategoryService
{
    // Get all categories
    Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync();

    // Get category by id
    Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id);

    // Create category
    Task<ReadCategoryDto> CreateCategoryAsync(CreateCategoryDto category);

    // Update category
    Task<ReadCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto category);

    // Delete category
    Task<bool> DeleteCategoryAsync(Guid id);

    // Search category by name
    Task<IEnumerable<ReadCategoryDto>> SearchCategoryByNameAsync(string categoryName);
}


