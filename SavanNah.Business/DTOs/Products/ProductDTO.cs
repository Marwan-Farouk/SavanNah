using SavanNah.Models.Models.ProductModel;
using SavanNah.Models.ViewModels;

namespace SavanNah.Business.DTOs.Products;

using SavanNah.Models.Models.CategoryProductModel;
using SavanNah.Models.Models.CategoryProductModel;

public class ProductDTO
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal Discount { get; set; }
    public int BrandId { get; set; }

    public Product ToEntity()
    {
        return new Product
        {
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            Discount = this.Discount,
            BrandId = this.BrandId
        };
    }
}

public class CreateProductDTO : ProductDTO
{
    public List<int> CategoryIds { get; set; }

    public static CreateProductDTO ToDTO(CreateProductVM vm)
    {
        return new CreateProductDTO
        {
            Name = vm.Product.Name,
            Price = vm.Product.Price,
            Description = vm.Product.Description,
            Discount = vm.Product.Discount,
            BrandId = vm.Product.BrandId,
            CategoryIds = vm.CategoryIds
        };
    }
} 
