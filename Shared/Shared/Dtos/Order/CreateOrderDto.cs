using Shared.Dtos.OrderItem;
using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Order;

public class CreateOrderDto
{
    [Required]
    public Guid CustomerId { get; set; }
    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    [Required]
    public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();

}
