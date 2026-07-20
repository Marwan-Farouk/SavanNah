using Microsoft.AspNetCore.Mvc.Rendering;
using SavanNah.Models.Models.BrandModel;
using SavanNah.Models.Models.CategoryModel;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.ViewModels;

public class ProductVM
{
    public Product Product { get; set; }

    public List<int> CategoryIds { get; set; } = [];

    public List<SelectListItem> Brands { get; set; } = [];

    public List<SelectListItem> Categories { get; set; } = [];

    public void AddBrands(IEnumerable<Brand> brands)
    {
        this.Brands = brands.Select(b => new SelectListItem
        {
            Value = b.Id.ToString(),
            Text = b.Name
        }).ToList();
    }
    public void AddCategories(IEnumerable<Category> categories)
    {
        this.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
    }
}

public class AllProductsVM
{
    public Product Product { get; set; }
    public string BrandName { get; set; }
    public List<String> CategoryNames { get; set; }

    //public static AllProductsVM ToVm(Product product)
    //{
    //    return new AllProductsVM
    //    {
    //        Product = product
    //    }
    //}
}