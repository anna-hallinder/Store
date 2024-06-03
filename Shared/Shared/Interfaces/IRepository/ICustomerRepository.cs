using MongoDB.Driver;
using Shared.Dtos.Customer;
using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface ICustomerRepository
{
    Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync();
    Task<CustomerEntity> GetCustomerByIdAsync(Guid id);
    Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer);
    Task<CustomerEntity> UpdateCustomerAsync(CustomerEntity customer);
    Task<bool> DeleteCustomerAsync(Guid id);
    Task<IEnumerable<CustomerEntity>> SearchCustomersByEmailAsync(string email);

    Task<CustomerEntity> GetCustomerByEmailAsync(string email);


}
