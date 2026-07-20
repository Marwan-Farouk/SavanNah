namespace SavanNah.Models.Models.ProductModel;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal Discount { get; set; }
    public int BrandId { get; set; }
    public BrandModel.Brand? Brand { get; set; }
    public ICollection<CategoryProductModel.CategoryProduct> CategoryProducts { get; set; } = [];
}
