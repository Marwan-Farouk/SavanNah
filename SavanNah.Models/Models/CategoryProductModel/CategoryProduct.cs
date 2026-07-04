namespace SavanNah.Models.Models.CategoryProductModel;

public class CategoryProduct
{
    public int CategoryId { get; set; }
    public CategoryModel.Category? Category { get; set; }

    public int ProductsId { get; set; }
    public ProductModel.Product? Products { get; set; }
}
