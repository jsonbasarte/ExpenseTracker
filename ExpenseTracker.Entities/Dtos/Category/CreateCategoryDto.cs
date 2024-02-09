using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Entities.Dtos.Category;

public class CreateCategoryDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
