using SavanNah.Models.Models.ProductModel;
using SavanNah.Models.ViewModels;

namespace SavanNah.Business.DTOs.Products;

public class ProductDTO
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
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

public class CreateProductDto : ProductDTO
{
    public List<int> CategoryIds { get; set; }

    public static CreateProductDto ToDto(ProductVM vm)
    {
        return new CreateProductDto
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

public class UpdateProductDTO : CreateProductDto
{
    public int Id { get; set; }
    public static new UpdateProductDTO ToDTO(ProductVM vm)
    {
        return new UpdateProductDTO
        {
            Id = vm.Product.Id,
            Name = vm.Product.Name,
            Price = vm.Product.Price,
            Description = vm.Product.Description,
            Discount = vm.Product.Discount,
            BrandId = vm.Product.BrandId,
            CategoryIds = vm.CategoryIds
        };
    }
    public new Product ToEntity()
    {
        return new Product
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            Discount = this.Discount,
            BrandId = this.BrandId
        };
    }
}