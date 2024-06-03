using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Category;

public class CreateCategoryDto
{
    [Required]
    public string CategoryName { get; set; } = string.Empty;
}