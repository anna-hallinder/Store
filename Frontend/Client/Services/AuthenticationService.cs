using Shared.Dtos.Customer;
using Shared.Interfaces.IService;

namespace Client.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AuthenticationService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<bool> LoginAsync(LoginCustomerDto loginCustomerDto)
    {
        var httpClient = _httpClientFactory.CreateClient("storeApi");
        var response = await httpClient.PostAsJsonAsync("api/auth/login", loginCustomerDto);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }

    public async Task<ReadCustomerDto> GetCustomerByEmailAsync(string email)
    {
        var httpClient = _httpClientFactory.CreateClient("storeApi");
        var response = await httpClient.GetAsync($"api/customers/email/{email}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ReadCustomerDto>();
    }
}
