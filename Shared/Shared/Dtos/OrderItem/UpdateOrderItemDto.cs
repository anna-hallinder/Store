using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.OrderItem;

public class UpdateOrderItemDto
{
    [Required]
    public Guid OrderItemId { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }
}
