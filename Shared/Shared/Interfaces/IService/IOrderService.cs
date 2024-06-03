using Shared.Dtos.Order;
using Shared.Entities;

namespace Shared.Interfaces.IService;

public interface IOrderService
{
    Task<IEnumerable<ReadOrderDto>> GetAllOrdersAsync();
    Task<ReadOrderDto> GetOrderByIdAsync(Guid id);
    Task<IEnumerable<ReadOrderDto>> GetOrdersByCustomerIdAsync(Guid customerId);
    Task<ReadOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);
    Task<ReadOrderDto> UpdateOrderAsync(Guid id, UpdateOrderDto updateOrderDto);
    Task<bool> DeleteOrderAsync(Guid id);
}

