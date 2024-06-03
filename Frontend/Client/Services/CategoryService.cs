using Shared.Dtos.Category;
using Shared.Dtos.Customer;
using Shared.Entities;
using Shared.Interfaces.IRepository;
using Shared.Interfaces.IService;

namespace Client.Services;

public class CategoryService : ICategoryService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public CategoryService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("storeApi");
    }

    public async Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadCategoryDto>>("api/categories");
    }

    public async Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ReadCategoryDto>($"api/categories/{id}");
    }

    public async Task<ReadCategoryDto> CreateCategoryAsync(CreateCategoryDto category)
    {
        var response = await _httpClient.PostAsJsonAsync("api/categories", category);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadCategoryDto>();
    }

    public async Task<ReadCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto category)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/categories/{id}", category);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadCategoryDto>();
    }

    public async Task<bool> DeleteCategoryAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/categories/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ReadCategoryDto>> SearchCategoryByNameAsync(string categoryName)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadCategoryDto>>($"api/categories/search?name={categoryName}");
    }
}
