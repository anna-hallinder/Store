using MongoDB.Driver;
using Shared.Dtos.Customer;
using Shared.Entities;
using Shared.Interfaces.IRepository;

namespace DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IMongoCollection<CustomerEntity> _customers;

    public CustomerRepository(MongoDbContext context)
    {
        _customers = context.Customers;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync()
    {
        return await _customers.Find(_ => true).ToListAsync();
    }

    public async Task<CustomerEntity> GetCustomerByIdAsync(Guid id)
    {
        return await _customers.Find(c => c.CustomerId == id).FirstOrDefaultAsync();
    }

    public async Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer)
    {
        await _customers.InsertOneAsync(customer);
        return customer;
    }

    public async Task<CustomerEntity> UpdateCustomerAsync(CustomerEntity customer)
    {
        await _customers.ReplaceOneAsync(c => c.CustomerId == customer.CustomerId, customer);
        return customer;
    }

    public async Task<bool> DeleteCustomerAsync(Guid id)
    {
        var result = await _customers.DeleteOneAsync(c => c.CustomerId == id);
        return result.DeletedCount > 0;
    }

    public async Task<IEnumerable<CustomerEntity>> SearchCustomersByEmailAsync(string email)
    {
        return await _customers.Find(customer => customer.Email.ToLower().Contains(email.ToLower())).ToListAsync();
    }

    public async Task<CustomerEntity> GetCustomerByEmailAsync(string email)
    {
        var filter = Builders<CustomerEntity>.Filter.Eq(c => c.Email.ToLower(), email.ToLower());
        return await _customers.Find(filter).FirstOrDefaultAsync();
    }




}

