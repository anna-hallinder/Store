using MongoDB.Driver;
using Shared.Entities;
using Shared.Interfaces.IRepository;

namespace DataAccess.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IMongoCollection<OrderEntity> _orders;

    public OrderRepository(MongoDbContext context)
    {
        _orders = context.Orders;
    }

    public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
    {
        return await _orders.Find(_ => true).ToListAsync();
    }

    public async Task<OrderEntity> GetOrderByIdAsync(Guid id)
    {
        return await _orders.Find(o => o.OrderId == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(Guid customerId)
    {
        return await _orders.Find(o => o.CustomerId == customerId).ToListAsync();
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
    {
        await _orders.InsertOneAsync(order);
        return order;
    }

    public async Task<OrderEntity> UpdateOrderAsync(OrderEntity order)
    {
        await _orders.ReplaceOneAsync(o => o.OrderId == order.OrderId, order);
        return order;
    }

    public async Task<bool> DeleteOrderAsync(Guid id)
    {
        var result = await _orders.DeleteOneAsync(o => o.OrderId == id);
        return result.DeletedCount > 0;
    }
}