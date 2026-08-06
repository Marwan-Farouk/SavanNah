using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SavanNah.Models.Models.CategoryModel;

public class Category
{
    public int Id { get; set; }
    [DisplayName("Name")]
    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
    [MinLength(10)]
    public string? Description { get; set; }
    public ICollection<CategoryProductModel.CategoryProduct> CategoryProducts { get; set; } = [];
}
