using System;
using Business.DTOs;

namespace Presentation.VMs;

public class CategoryVM
{
    public int id { get; set; }
    public required string Name { get; set; }
    public required string imageLoc { get; set; }
}

public class AllCategoriesVM
{
    public required string Name { get; set; }
    public required string imageLoc { get; set; }
}

public static class CategoryVmExtensions
{
    public static CategoryVM ToVM(this CategoryDTO dTO)
    {
        return new CategoryVM
        {
            id = dTO.id,
            Name = dTO.Name,
            imageLoc = dTO.imageLoc
        };
    }
    public static AllCategoriesVM ToVMAll(this AllCategoriesDTO dTO)
    {
        return new AllCategoriesVM
        {
            Name = dTO.Name,
            imageLoc = dTO.imageLoc
        };
    }
}