namespace Shared.Dtos.Category;

public class ReadCategoryDto
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}