using Shared.Dtos.OrderItem;

namespace Shared.Dtos.Order;

public class ReadOrderDto
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal OrderTotalAmount { get; set; }
    public List<ReadOrderItemDto> OrderItems { get; set; } = new List<ReadOrderItemDto>();
}
