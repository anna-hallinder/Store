using Shared.Entities;

namespace Shared.Interfaces.IRepository;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllOrdersAsync();
    Task<OrderEntity> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<OrderEntity> CreateOrderAsync(OrderEntity order);
    Task<OrderEntity> UpdateOrderAsync(OrderEntity order);
    Task<bool> DeleteOrderAsync(Guid id);
}