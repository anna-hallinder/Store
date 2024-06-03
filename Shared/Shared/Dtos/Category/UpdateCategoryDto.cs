using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.Category;

public class UpdateCategoryDto
{
    [Required]
    public string CategoryName { get; set; } = string.Empty;
}