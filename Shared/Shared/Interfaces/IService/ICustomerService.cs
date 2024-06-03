using MongoDB.Driver;
using Shared.Dtos.Customer;
using Shared.Entities;

namespace Shared.Interfaces.IService;

public interface ICustomerService
{
    Task<IEnumerable<ReadCustomerDto>> GetAllCustomersAsync();
    Task<ReadCustomerDto> GetCustomerByIdAsync(Guid id);
    Task<ReadCustomerDto> CreateCustomerAsync(CreateCustomerDto createCustomerDto);
    Task<ReadCustomerDto> UpdateCustomerAsync(Guid id, UpdateCustomerDto updateCustomerDto);
    Task<bool> DeleteCustomerAsync(Guid id);
    Task<IEnumerable<ReadCustomerDto>> SearchCustomersByEmailAsync(string email);

    Task<ReadCustomerDto?> GetCustomerByEmailAsync(string email);

}
