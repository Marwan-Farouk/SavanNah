using System;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }


    public DbSet<Category> Categories { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData([
            new Category {id = 1 , Name = "Tech" , imageLoc = "tech.webp"},
            new Category {id = 2 , Name = "Food" , imageLoc = "food.jpg"},
            new Category {id = 3 , Name = "Fashion" , imageLoc = "fashion.jpeg"}
        ]);
    }
}
