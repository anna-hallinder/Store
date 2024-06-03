namespace Shared.Dtos.Product;

public class ReadProductDto
{
    public Guid ProductId { get; set; }
    public string ProductArticleNumber { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public decimal ProductUnitPrice { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
