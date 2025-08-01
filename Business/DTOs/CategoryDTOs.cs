using System;
using DataAccess.Entities;

namespace Business.DTOs;

public class AllCategoriesDTO
{
    public required string Name { get; set; }
    public required string imageLoc { get; set; }
}
public class CategoryDTO
{
    public int id { get; set; }
    public required string Name { get; set; }
    public required string imageLoc { get; set; }
}

public static class CategoryDTOExtentions
{
    public static Category ToEntity(this CategoryDTO dto)
    {
        return new Category
        {
            id = dto.id,
            Name = dto.Name,
            imageLoc = dto.imageLoc
        };
    }

    public static CategoryDTO ToDTO(this Category entity)
    {
        return new CategoryDTO
        {
            id = entity.id,
            Name = entity.Name,
            imageLoc = entity.imageLoc
        };
    }
    public static AllCategoriesDTO ToDTOAll(this Category entity)
    {
        return new AllCategoriesDTO
        {
            Name = entity.Name,
            imageLoc = entity.imageLoc
        };
    }
}