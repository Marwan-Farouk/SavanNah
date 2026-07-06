using Microsoft.AspNetCore.Mvc.Rendering;
using SavanNah.Models.Models.ProductModel;

namespace SavanNah.Models.ViewModels;

public class ProductVM
{
    public Product Product { get; set; }

    public List<int> CategoryIds { get; set; } = [];

    public List<SelectListItem> Brands { get; set; } = [];

    public List<SelectListItem> Categories { get; set; } = [];

}