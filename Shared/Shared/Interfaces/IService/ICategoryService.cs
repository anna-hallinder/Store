using Shared.Dtos.Category;
using Shared.Entities;

namespace Shared.Interfaces.IService;

public interface ICategoryService
{
    Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync();
    Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id);
    Task<ReadCategoryDto> CreateCategoryAsync(CreateCategoryDto category);
    Task<ReadCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto category);
    Task<bool> DeleteCategoryAsync(Guid id);
    Task<IEnumerable<ReadCategoryDto>> SearchCategoryByNameAsync(string categoryName);
}


