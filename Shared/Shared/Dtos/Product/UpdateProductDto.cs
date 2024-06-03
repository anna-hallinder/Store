using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Product;

public class UpdateProductDto
{
    [Required]
    public string ProductArticleNumber { get; set; } = string.Empty;
    [Required]
    public string ProductName { get; set; } = string.Empty;
    [Required]
    public string ProductDescription { get; set; } = string.Empty;
    [Required]
    public decimal ProductUnitPrice { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    [Required]
    public string Status { get; set; } = string.Empty;
}