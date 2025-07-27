using System;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }


    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData([
            new Category {id = 1 , Name = "Tech" , DisplayOrder = 1},
            new Category {id = 2 , Name = "Food" , DisplayOrder = 2},
            new Category {id = 3 , Name = "Fashion" , DisplayOrder = 3}
        ]);
    }
}
