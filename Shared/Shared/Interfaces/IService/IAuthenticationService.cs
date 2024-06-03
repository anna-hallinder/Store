using Shared.Dtos.Customer;

namespace Shared.Interfaces.IService;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(LoginCustomerDto loginCustomerDto);
}