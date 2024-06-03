using Shared.Dtos.Customer;
using Shared.Interfaces.IService;

namespace Client.Services;

public class CustomerService : ICustomerService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public CustomerService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("storeApi");
    }

    public async Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadCustomerDto>>("api/customers");
    }

    public async Task<ReadCustomerDto> GetCustomerByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ReadCustomerDto>($"api/customers/{id}");
    }

    public async Task<ReadCustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/customers", createCustomerDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadCustomerDto>();
    }

    public async Task<ReadCustomerDto> UpdateCustomerAsync(Guid id, UpdateCustomerDto updateCustomerDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", updateCustomerDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadCustomerDto>();
    }

    public async Task<bool> DeleteCustomerAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/customers/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ReadCustomerDto>> SearchCustomersByEmailAsync(string email)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadCustomerDto>>($"api/customers/search?email={email}");
    }


    public async Task<ReadCustomerDto?> GetCustomerByEmailAsync(string email)
    {
        return await _httpClient.GetFromJsonAsync<ReadCustomerDto>($"api/customers/search?email={email}");
    }
}
