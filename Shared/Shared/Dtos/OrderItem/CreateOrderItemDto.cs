using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.OrderItem;

public class CreateOrderItemDto
{
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public int Quantity { get; set; }
    [Required]
    public decimal UnitPrice { get; set; }

    
}