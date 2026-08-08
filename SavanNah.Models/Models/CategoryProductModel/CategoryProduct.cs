using SavanNah.Models.Models.CategoryModel;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.Models.CategoryProductModel;

public class CategoryProduct
{
    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public int ProductsId { get; set; }
    public Product? Products { get; set; }
}
