namespace SavanNah.Models.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal Discount { get; set; }
    public IEnumerable<Category> Categories { get; set; } = [];
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}