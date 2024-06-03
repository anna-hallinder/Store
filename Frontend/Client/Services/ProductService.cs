using Shared.Dtos.Product;
using Shared.Interfaces.IService;

namespace Client.Services;

public class ProductService : IProductService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("storeApi");
    }

    public async Task<IEnumerable<ReadProductDto>> GetAllProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadProductDto>>("api/products");
    }

    public async Task<ReadProductDto> GetProductByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ReadProductDto>($"api/products/{id}");
    }

    public async Task<ReadProductDto> CreateProductAsync(CreateProductDto createProductDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/products", createProductDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadProductDto>();
    }

    public async Task<ReadProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateProductDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/products/{id}", updateProductDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadProductDto>();
    }

    public async Task<bool> DeleteProductAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/products/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ReadProductDto>> SearchProductByNameAsync(string productName)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadProductDto>>($"api/products/search?name={productName}");
    }

    public async Task<IEnumerable<ReadProductDto>> SearchProductByArticleNumberAsync(string articleNumber)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadProductDto>>($"api/products/search-by-article-number?articleNumber={articleNumber}");
    }
}
