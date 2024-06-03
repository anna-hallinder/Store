using System.ComponentModel.DataAnnotations;
using Shared.Dtos.OrderItem;

namespace Shared.Dtos.Order;

public class UpdateOrderDto
{
    [Required]
    public DateTime OrderDate { get; set; }
    [Required]
    public List<UpdateOrderItemDto> OrderItems { get; set; } = new List<UpdateOrderItemDto>();
}
