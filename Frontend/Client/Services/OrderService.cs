using Shared.Dtos.Order;
using Shared.Dtos.OrderItem;
using Shared.Entities;
using Shared.Interfaces.IService;

namespace Client.Services;

public class OrderService : IOrderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public OrderService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _httpClient = _httpClientFactory.CreateClient("storeApi");
    }

    public async Task<IEnumerable<ReadOrderDto>> GetAllOrdersAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadOrderDto>>("api/orders");
    }

    public async Task<ReadOrderDto> GetOrderByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ReadOrderDto>($"api/orders/{id}");
    }

    public async Task<IEnumerable<ReadOrderDto>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReadOrderDto>>($"api/orders/by-customer-id/{customerId}");
    }

    public async Task<ReadOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/orders", createOrderDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadOrderDto>();
    }

    public async Task<ReadOrderDto> UpdateOrderAsync(Guid id, UpdateOrderDto updateOrderDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/orders/{id}", updateOrderDto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ReadOrderDto>();
    }

    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/orders/{id}");
        return response.IsSuccessStatusCode;
    }
}
