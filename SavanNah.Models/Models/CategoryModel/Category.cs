using System.ComponentModel;

namespace SavanNah.Models.Models.CategoryModel;

public class Category
{
    public int Id { get; set; }
    [DisplayName("Name")]
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<CategoryProductModel.CategoryProduct> CategoryProducts { get; set; } = [];
}
