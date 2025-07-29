using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Category
{
    [Key]
    public int id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }

}
